import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialog } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { of } from 'rxjs';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/dialogs/login/login.component';
import { loginLocalStorage, logout } from './store/user/user.actions';

describe('AppComponent', () => {
  const store = {
    dispatch: jest.fn(),
    select: jest.fn(() => of()),
  };

  const translate = {
    use: jest.fn(),
    get: jest.fn(),
  };

  const dialog = {
    open: jest.fn(),
  };

  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AppComponent],
      providers: [
        { provide: Store, useValue: store },
        { provide: TranslateService, useValue: translate },
        { provide: MatDialog, useValue: dialog },
      ],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  describe('ngOnInit', () => {
    it('should dispatch login from local storage action', () => {
      expect(store.dispatch).toHaveBeenCalledWith(loginLocalStorage());
    });
  });

  it('should change language', () => {
    component.changeLanguage('en');
    expect(translate.use).toHaveBeenCalled();
  });

  it('should open login dialog', () => {
    component.login();
    expect(dialog.open).toHaveBeenCalledWith(LoginComponent);
  });

  it('should dispatch logout action', () => {
    component.logout();
    expect(store.dispatch).toHaveBeenCalledWith(logout());
  });
});
