import * as Sentry from '@sentry/browser';
import jwt_decode from 'jwt-decode';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { catchError, map, of, switchMap, tap } from 'rxjs';
import {
  login,
  loginError,
  loginLocalStorage,
  loginSuccess,
  logout,
  logoutSuccess,
} from './user.actions';
import { UserService } from '../../services/user.service';
import { JwtToken } from '../../model/jwt-token.model';

@Injectable()
export class UserEffects {
  private localStorageKey = 'accessToken';

  constructor(private action$: Actions, private userService: UserService) {}

  login$ = createEffect(() =>
    this.action$.pipe(
      ofType(login),
      switchMap(({ username, password }) =>
        this.userService.login(username, password).pipe(
          map(({ accessToken }) => this.processAccessToken(accessToken)),
          catchError(() => of(loginError()))
        )
      )
    )
  );

  loginLocalStorage = createEffect(() =>
    this.action$.pipe(
      ofType(loginLocalStorage),
      map(() =>
        this.processAccessToken(
          localStorage.getItem(this.localStorageKey) as string | undefined
        )
      )
    )
  );

  logout$ = createEffect(() =>
    this.action$.pipe(
      ofType(logout),
      map(() => {
        localStorage.removeItem(this.localStorageKey);
        Sentry.configureScope(scope => scope.setUser(null));
        return logoutSuccess();
      })
    )
  );

  private processAccessToken(accessToken: string | undefined): Action {
    if (accessToken) {
      const payload = jwt_decode(accessToken) as JwtToken;
      if (payload.exp * 1000 < Date.now()) {
        // expired - logout
        return logout();
      }

      // not expired - login user
      localStorage.setItem(this.localStorageKey, accessToken);
      return loginSuccess({
        accessToken,
        user: {
          username: payload.given_name,
          role: payload.role,
        },
      });
    }
    return loginError(); // login failed
  }
}
