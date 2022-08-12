import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, of } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  public login(username: string, password: string) {
    return this.http.post<{ accessToken: string }>(`${this.baseUrl}/login`, {
      username,
      password
    })
    .pipe(catchError(() => of({ accessToken: undefined })));
  }
}
