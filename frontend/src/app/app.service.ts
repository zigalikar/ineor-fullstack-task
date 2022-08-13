import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { environment } from '../environments/environment';
import { Beach } from './model/beach.model';

@Injectable({
  providedIn: 'root',
})
export class AppService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  public getList(
    query?: string,
    page: number = 0,
    perPage = 5,
    sortBy = 'name'
  ): Observable<{ items: Beach[]; totalCount: number }> {
    return this.http
      .get<{ items: Beach[]; totalCount: number }>(
        `${this.baseUrl}/beaches?query=${
          query ? encodeURI(query) : ''
        }&page=${page}&perPage=${perPage}&sortBy=${
          sortBy ? encodeURI(sortBy) : ''
        }`
      )
      .pipe(catchError(() => of({ items: [], totalCount: 0 })));
  }

  public get(id: string): Observable<Beach | undefined> {
    return this.http
      .get<Beach>(`${this.baseUrl}/beaches/${id}`)
      .pipe(catchError(() => of(undefined)));
  }

  public create(data: Beach): Observable<Beach | undefined> {
    return this.http
      .post<Beach>(`${this.baseUrl}/beaches`, data)
      .pipe(catchError(() => of(undefined)));
  }

  public edit(id: string, data: Beach): Observable<Beach | undefined> {
    return this.http
      .put<Beach>(`${this.baseUrl}/beaches/${id}`, data)
      .pipe(catchError(() => of(undefined)));
  }

  public delete(id: string): Observable<Beach | undefined> {
    return this.http
      .delete<Beach>(`${this.baseUrl}/beaches/${id}`)
      .pipe(catchError(() => of(undefined)));
  }
}
