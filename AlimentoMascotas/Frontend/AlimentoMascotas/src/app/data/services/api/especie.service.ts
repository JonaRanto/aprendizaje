import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API_ROUTES, ERROR_CONST } from '@data/constants';
import { IApiResponse } from '@data/interfaces';
import { catchError, map, Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EspecieService {

  constructor(
    private http: HttpClient,
  ) { }
  
  getEspecies(): Observable<IApiResponse> {
    const response = {
      error: true,
      message: ERROR_CONST.ESPECIE.DEFAULT_ERROR,
      data: null,
    };
    return this.http.get<IApiResponse>(`${API_ROUTES.ESPECIE}/listar`)
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
    );
  }
}
