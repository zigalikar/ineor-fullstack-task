import * as Sentry from '@sentry/browser';
import { createReducer, on } from '@ngrx/store';
import { User } from '../../model/user.model';
import { login, loginError, loginSuccess, logoutSuccess } from './user.actions';

export interface UserState {
  user: User | undefined;
  accessToken: string | undefined;
  loggingIn: boolean;
}

export const initialState: UserState = {
  user: undefined,
  accessToken: undefined,
  loggingIn: false,
};

export const userReducer = createReducer(
  initialState,
  on(login, (state) => ({ ...state, user: undefined, loggingIn: true })),
  on(loginSuccess, (state, { user, accessToken }) => {
    Sentry.configureScope(scope => scope.setUser({ username: user.username }));
    return { ...state, user, accessToken, loggingIn: false };
  }),
  on(loginError, (state) => ({ ...state, loggingIn: false })),
  on(logoutSuccess, (state) => ({ ...state, user: undefined, accessToken: undefined, loggingIn: false })),
);
