import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IApiResponse } from '@data/interfaces';
import { catchError, map, Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(
    private http: HttpClient,
  ) { }

  getList(endPoint: string, defaultError: string): Observable<IApiResponse> {
    const response = {
      error: true,
      message: defaultError,
      data: null,
    }
    return this.http.get<IApiResponse>(endPoint)
    .pipe(
      map((r: IApiResponse) => {
        response.error = r.error;
        response.message = r.message;
        response.data = r.data;
        return response;
      }),
      catchError(_ => {
        return of(response);
      })
    )
  }
}
