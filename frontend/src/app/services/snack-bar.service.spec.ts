import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { SnackBarService } from './snack-bar.service';
import { environment } from '../../environments/environment';
import { MatSnackBar } from '@angular/material/snack-bar';

describe('SnackBarService', () => {
  let service: SnackBarService;
  let matSnackBar: MatSnackBar;

  beforeEach(() => {
    environment.apiUrl = 'url';

    TestBed.configureTestingModule({
      imports: [HttpClientModule],
    });
    service = TestBed.inject(SnackBarService);
    matSnackBar = TestBed.inject(MatSnackBar);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should call open on .open', () => {
    jest.spyOn(matSnackBar, 'open');

    service.open('text');
    expect(matSnackBar.open).toHaveBeenCalled();
  });
});
