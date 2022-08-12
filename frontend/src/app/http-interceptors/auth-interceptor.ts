import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectAccessToken } from '../store/user/user.selectors';
import { Observable, switchMap, take } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private store: Store) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return this.store
      .select(selectAccessToken)
      .pipe(
        take(1),
        switchMap((accessToken) => {
          if (accessToken) {
            return next.handle(req.clone({
              headers: req.headers.set('Authorization', `Bearer ${accessToken}`)
            }));
          }
          return next.handle(req);
        })
      );
  }
}
