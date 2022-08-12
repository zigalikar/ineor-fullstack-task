import { createAction, props } from '@ngrx/store';
import { User } from '../../model/user.model';

export const login = createAction(
  '[User] Login',
  props<{ username: string; password: string }>(),
);
 
export const loginLocalStorage = createAction('[User] Login Local Storage');
 
export const loginSuccess = createAction(
  '[User] Login Success',
  props<{ accessToken: string; user: User }>(),
);
 
export const loginError = createAction('[User] Login Error');
 
export const logout = createAction('[User] Logout');
export const logoutSuccess = createAction('[User] Logout Success');
export const logoutError = createAction('[User] Logout Error');
