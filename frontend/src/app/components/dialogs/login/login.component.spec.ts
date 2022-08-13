import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Store } from '@ngrx/store';

import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  const store = {
    dispatch: jest.fn(),
  };

  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LoginComponent],
      providers: [{ provide: Store, useValue: store }],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should login', () => {
    component.form.setValue({
      username: 'username',
      password: 'password',
    });
    component.login();

    expect(store.dispatch).toHaveBeenCalled();
  });
});
