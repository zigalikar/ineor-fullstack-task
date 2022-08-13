import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialog } from '@angular/material/dialog';

import { ItemComponent } from './item.component';

describe('ItemComponent', () => {
  const dialog = {
    open: jest.fn(),
  };

  let component: ItemComponent;
  let fixture: ComponentFixture<ItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ItemComponent],
      providers: [{ provide: MatDialog, useValue: dialog }],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should open edit dialog', () => {
    component.edit();

    expect(dialog.open).toHaveBeenCalled();
  });

  it('should open delete dialog', () => {
    component.delete();

    expect(dialog.open).toHaveBeenCalled();
  });
});
