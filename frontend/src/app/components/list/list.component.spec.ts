import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialog } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { of } from 'rxjs';
import { CreateComponent } from '../dialogs/create/create.component';
import { ListComponent } from './list.component';

describe('ListComponent', () => {
  const store = {
    dispatch: jest.fn(),
    select: jest.fn(() => of()),
  };

  const dialog = {
    open: jest.fn(),
  };

  let component: ListComponent;
  let fixture: ComponentFixture<ListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListComponent],
      providers: [
        { provide: Store, useValue: store },
        { provide: MatDialog, useValue: dialog },
      ],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should open create dialog', () => {
    component.create();

    expect(dialog.open).toHaveBeenCalledWith(CreateComponent);
  });

  it('should navigate to page', () => {
    const page = 4;
    jest.spyOn(component, 'load');
    component.navigateToPage(page);

    expect(component.page).toEqual(page);
    expect(component.load).toHaveBeenCalled();
  });

  it('should load', () => {
    component.load();

    expect(component.load).toHaveBeenCalled();
  });
});
