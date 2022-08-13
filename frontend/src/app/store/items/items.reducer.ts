import { createReducer, on } from '@ngrx/store';
import { Beach } from '../../model/beach.model';
import {
  itemsLoadedError,
  itemsLoadedSuccess,
  loadItems,
} from './items.actions';

export interface ItemsState {
  items: Beach[] | undefined;
  totalCount: number | undefined;
  error: string | undefined;
}

export const initialState: ItemsState = {
  items: undefined,
  totalCount: undefined,
  error: undefined,
};

export const itemsReducer = createReducer(
  initialState,
  on(loadItems, state => ({ ...state, items: undefined })),
  on(itemsLoadedSuccess, (state, { items, totalCount }) => ({
    ...state,
    items,
    totalCount,
  })),
  on(itemsLoadedError, (state, { error }) => ({ ...state, error }))
);
