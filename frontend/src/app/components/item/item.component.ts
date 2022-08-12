import { Component, ElementRef, Input, OnChanges, OnDestroy, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateComponent } from '../dialogs/create/create.component';
import { Subject, takeUntil } from 'rxjs';
import { DeleteComponent } from '../dialogs/delete/delete.component';
import { Store } from '@ngrx/store';
import { Beach } from '../../model/beach.model';
import { selectUser } from '../../store/user/user.selectors';
import { UserService } from '../../services/user.service';
import { countries } from '../../data/countries';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnChanges, OnDestroy {
  @Input() item!: Beach;
  @Output() modified = new Subject<void>();

  @ViewChild('description') description: ElementRef<HTMLParagraphElement> | undefined;

  user = this.store.select(selectUser);

  countryName: string | undefined;

  buttonText = 'ITEM.SHOW_MORE';

  private destroy$ = new Subject<void>();

  constructor(private dialog: MatDialog, private store: Store, public userService: UserService) {}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['item'])
      this.countryName = countries.find((country) => country.code === this.item.country)?.name;
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  edit(): void {
    this.dialog.open(CreateComponent, {
      data: this.item,
    })
    .afterClosed()
    .pipe(takeUntil(this.destroy$))
    .subscribe((edited) => {
      if (edited)
        this.modified.next();
    });
  }

  delete(): void {
    this.dialog.open(DeleteComponent, {
      data: this.item
    })
    .afterClosed()
    .pipe(takeUntil(this.destroy$))
    .subscribe((deleted) => {
      if (deleted)
        this.modified.next();
    });
  }

  toggleDescription(): void {
    this.description?.nativeElement.classList.toggle('active');
    this.buttonText = this.description?.nativeElement.classList.contains('active') ? 'ITEM.SHOW_LESS' : 'ITEM.SHOW_MORE';
  }
}
