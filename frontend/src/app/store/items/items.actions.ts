import { createAction, props } from '@ngrx/store';
import { Beach } from '../../model/beach.model';

export const loadItems = createAction(
  '[Items] Load',
  props<{ page?: number; perPage?: number; sortBy?: string; query?: string }>()
);

export const itemsLoadedSuccess = createAction(
  '[Items] Loaded Success',
  props<{ items: Beach[]; totalCount: number }>()
);

export const itemsLoadedError = createAction(
  '[Items] Loaded Error',
  props<{ error: string }>()
);
