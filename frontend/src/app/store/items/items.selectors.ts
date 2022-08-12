import { createFeatureSelector, createSelector } from '@ngrx/store';
import { ItemsState } from './items.reducer';

const select = createFeatureSelector<ItemsState>('items');

export const selectItems = createSelector(select, (state) => state.items);
export const selectTotalCount = createSelector(select, (state) => state.totalCount);
export const selectItemsError = createSelector(select, (state) => state.error);