import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { Actions, ofType } from '@ngrx/effects';
import { SnackBarService } from '../../../services/snack-bar.service';
import { selectLoggingIn } from '../../../store/user/user.selectors';
import {
  login,
  loginError,
  loginSuccess,
} from '../../../store/user/user.actions';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  logging = this.store.select(selectLoggingIn);

  constructor(
    private store: Store,
    private actions: Actions,
    private dialogRef: MatDialogRef<LoginComponent>,
    private snackBarService: SnackBarService
  ) {
    this.form = new FormGroup({
      username: new FormControl(undefined, [Validators.required]),
      password: new FormControl(undefined, [Validators.required]),
    });
  }

  ngOnInit(): void {
    this.actions.pipe(ofType(loginSuccess)).subscribe(({ user }) => {
      this.snackBarService.open('USER.SUCCESSFUL', {
        interpolateParams: {
          username: user.username,
        },
      });
      this.dialogRef.close();
    });

    this.actions.pipe(ofType(loginError)).subscribe(() => {
      this.snackBarService.open('USER.FAILURE');
    });
  }

  login(): void {
    if (this.form.valid) {
      this.store.dispatch(
        login({
          username: this.form.get('username')!.value,
          password: this.form.get('password')!.value,
        })
      );
    }
  }
}
