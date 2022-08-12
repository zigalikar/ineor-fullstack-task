import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog'
import { AppService } from '../../../app.service';
import { countries } from '../../../data/countries';
import { Beach } from '../../../model/beach.model';
import { SnackBarService } from '../../../services/snack-bar.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent {
  form: FormGroup;
  countries = countries;
  creating = false;

  constructor(@Inject(MAT_DIALOG_DATA) public data: Beach | undefined, private service: AppService, private snackBarService: SnackBarService, private matDialogRef: MatDialogRef<CreateComponent>) {
    this.form = new FormGroup({
      name: new FormControl(data?.name, [Validators.required, Validators.maxLength(100)]),
      description: new FormControl(data?.description, [Validators.maxLength(1000)]),
      imageUrl: new FormControl(data?.imageUrl, [Validators.required, Validators.pattern('(https?://)?([\\da-z.-]+)\\.([a-z.]{2,6})[/\\w .-]*/?')]),
      country: new FormControl(data?.country, [Validators.required]),
    });
  }

  create(): void {
    if (this.form.valid) {
      if (this.form.dirty) {
        const item = { ...this.data } ?? {};
        item.name = this.form.get('name')!.value;
        item.description = this.form.get('description')!.value;
        item.imageUrl = this.form.get('imageUrl')!.value;
        item.country = this.form.get('country')!.value;
    
        this.creating = true;
        (this.data
          ? this.service.edit(this.data.id, item as Beach)
          : this.service.create(item as Beach))
          .subscribe((item) => {
            this.snackBarService.open(item ? 'CREATE.SUCCESSFUL' : 'CREATE.FAILED');
            this.creating = false;
            this.matDialogRef.close(item);
          });
      }
      else
        this.matDialogRef.close();
    }
  }
}
