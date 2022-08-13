import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppService } from '../../../app.service';

import { DeleteComponent } from './delete.component';

describe('DeleteComponent', () => {
  const service = {
    delete: jest.fn(),
  };

  let component: DeleteComponent;
  let fixture: ComponentFixture<DeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeleteComponent],
      providers: [{ provide: AppService, useValue: service }],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call service delete', () => {
    component.confirm();

    expect(component.deleting).toEqual(true);
    expect(service.delete).toHaveBeenCalled();
  });
});
