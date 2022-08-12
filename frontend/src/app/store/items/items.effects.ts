import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, of, switchMap } from 'rxjs';
import { AppService } from '../../app.service';
import { itemsLoadedError, itemsLoadedSuccess, loadItems } from './items.actions';

@Injectable()
export class ItemsEffects {
  constructor(private action$: Actions, private service: AppService) {}

  load$ = createEffect(() =>
    this.action$.pipe(
      ofType(loadItems),
      switchMap((action) => this.service.getList(action.query, action.page, action.perPage, action.sortBy).pipe(
        map((data) => itemsLoadedSuccess(data)),
        catchError((error) => of(itemsLoadedError({ error }))),
      )),
    )
  );
}