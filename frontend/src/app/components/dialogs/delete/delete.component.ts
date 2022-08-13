import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { AppService } from '../../../app.service';
import { Beach } from '../../../model/beach.model';
import { SnackBarService } from '../../../services/snack-bar.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.scss'],
})
export class DeleteComponent {
  deleting = false;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: Beach,
    private service: AppService,
    private matDialogRef: MatDialogRef<DeleteComponent>,
    private snackBarService: SnackBarService
  ) {}

  confirm(): void {
    this.deleting = true;
    this.service.delete(this.data.id).subscribe(deleted => {
      this.snackBarService.open(
        deleted ? 'DELETE.SUCCESSFUL' : 'DELETE.FAILED'
      );
      this.deleting = false;
      this.matDialogRef.close(deleted);
    });
  }
}
