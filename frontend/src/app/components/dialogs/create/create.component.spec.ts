import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppService } from '../../../app.service';

import { CreateComponent } from './create.component';

describe('CreateComponent', () => {
  const service = {
    create: jest.fn(),
  };

  let component: CreateComponent;
  let fixture: ComponentFixture<CreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CreateComponent],
      providers: [
        { provide: AppService, useValue: service },
      ],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call service create', () => {
    component.form.setValue({
      name: 'name',
      description: 'description',
      imageUrl: 'https://www.google.com',
      country: 'country',
    });
    component.form.markAsDirty();

    expect(service.create).toHaveBeenCalled();
  });
});
