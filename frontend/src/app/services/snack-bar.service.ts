import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar'
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class SnackBarService {
  constructor(private snackBar: MatSnackBar, private translate: TranslateService) {}

  public open(text: string, options?: { interpolateParams: any }): void {
    this.snackBar.open(this.translate.instant(text, options?.interpolateParams), undefined, {
      duration: 5000,
    });
  }
}