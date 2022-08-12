import { Component, OnDestroy, OnInit } from '@angular/core';
import { debounceTime, filter, startWith, Subject, takeUntil, tap } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { CreateComponent } from '../dialogs/create/create.component';
import { FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { selectUser } from '../../store/user/user.selectors';
import { Beach } from '../../model/beach.model';
import { selectItems, selectTotalCount } from '../../store/items/items.selectors';
import { loadItems } from '../../store/items/items.actions';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit, OnDestroy {
  items: Beach[] | undefined;

  form: FormGroup;

  user = this.store.select(selectUser);

  sortOptions = [
    { name: 'ITEM.NAME', value: 'Name' },
    { name: 'ITEM.COUNTRY', value: 'Country' },
  ];

  typingSearch = false;
  page: number = 0;
  perPage: number = 6;
  pagesCount = 1;

  private destroy$ = new Subject<void>();

  constructor(private dialog: MatDialog, private store: Store) {
    this.form = new FormGroup({
      search: new FormControl(),
      sortBy: new FormControl(this.sortOptions[0].value),
    });
  }

  ngOnInit(): void {
    this.form.valueChanges
      .pipe(
        tap(() => this.items = undefined),
        takeUntil(this.destroy$),
        debounceTime(500),
        startWith({}),
      )
      .subscribe(() => this.load());

    this.store.select(selectItems)
      .pipe(takeUntil(this.destroy$))
      .subscribe((items) => this.items = items);

    this.store.select(selectTotalCount)
      .pipe(
        takeUntil(this.destroy$),
        filter((count) => !!count),
      )
      .subscribe((count) => this.pagesCount = Math.ceil(count! / this.perPage));
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  create(): void {
    this.dialog.open(CreateComponent)
      .afterClosed()
      .pipe(takeUntil(this.destroy$))
      .subscribe((created) => {
        if (created)
          this.load();
      });
  }

  navigateToPage(page: number): void {
    this.page = page;
    this.load();
  }

  load() {
    this.store.dispatch(loadItems({
      query: this.form.get('search')?.value ?? '',
      sortBy: this.form.get('sortBy')?.value,
      page: this.page,
      perPage: this.perPage,
    }));
  }
}
