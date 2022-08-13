import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import {
  HttpClient,
  HttpClientModule,
  HTTP_INTERCEPTORS,
} from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { ListComponent } from './components/list/list.component';
import { CreateComponent } from './components/dialogs/create/create.component';
import { DeleteComponent } from './components/dialogs/delete/delete.component';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { ReactiveFormsModule } from '@angular/forms';
import { SkeletonComponent } from './components/skeleton/skeleton.component';
import { TimesPipe } from './pipes/times.pipe';
import { ItemComponent } from './components/item/item.component';
import { LoginComponent } from './components/dialogs/login/login.component';
import { AuthInterceptor } from './http-interceptors/auth-interceptor';
import { ItemsEffects } from './store/items/items.effects';
import { itemsReducer } from './store/items/items.reducer';
import { userReducer } from './store/user/user.reducer';
import { UserEffects } from './store/user/user.effects';
import { getErrorHandler } from './sentry/sentry-error-handler';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    CreateComponent,
    DeleteComponent,
    SkeletonComponent,
    TimesPipe,
    ItemComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    TranslateModule.forRoot({
      defaultLanguage: 'sl',
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      },
    }),
    StoreModule.forRoot({
      items: itemsReducer,
      user: userReducer,
    }),
    EffectsModule.forRoot([ItemsEffects, UserEffects]),
    MatToolbarModule,
    MatMenuModule,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    MatGridListModule,
    MatCardModule,
    MatButtonModule,
    MatDialogModule,
    MatSnackBarModule,
  ],
  providers: [
    {
      provide: ErrorHandler,
      useValue: getErrorHandler(),
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
