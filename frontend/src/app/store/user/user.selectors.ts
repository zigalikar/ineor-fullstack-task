import { createFeatureSelector, createSelector } from '@ngrx/store';
import { UserState } from './user.reducer';

const select = createFeatureSelector<UserState>('user');

export const selectUser = createSelector(select, (state) => state.user);
export const selectLoggingIn = createSelector(select, (state) => state.loggingIn);
export const selectAccessToken = createSelector(select, (state) => state.accessToken);
