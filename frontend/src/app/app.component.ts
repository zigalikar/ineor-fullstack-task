import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { UserService } from './services/user.service';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from './components/dialogs/login/login.component';
import { Store } from '@ngrx/store';
import { loginLocalStorage, logout } from './store/user/user.actions';
import { selectUser } from './store/user/user.selectors';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  user = this.store.select(selectUser);

  constructor(
    private translate: TranslateService,
    private store: Store,
    public userService: UserService,
    private dialog: MatDialog,
    private cd: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.store.dispatch(loginLocalStorage());
  }

  changeLanguage(language: string): void {
    this.translate.use(language);
  }

  login(): void {
    this.dialog
      .open(LoginComponent)
      .afterClosed()
      .subscribe(() => this.cd.detectChanges());
  }

  logout(): void {
    this.store.dispatch(logout());
  }
}
