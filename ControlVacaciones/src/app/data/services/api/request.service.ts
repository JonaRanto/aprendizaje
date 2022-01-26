import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ERRORS_CONST } from '@data/constants';
import { API_ROUTES } from '@data/constants/routes';
import { IApiResponse, IApiRequest } from '@data/interfaces';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  constructor(
    private http: HttpClient
  ) { }

  getRequestsFromUser(idUser: number): Observable<IApiResponse> {
    const response = { error: true, msg: ERRORS_CONST.REQUEST.HISTORY_NOT_FOUND, data: null }
    return this.http.get<IApiRequest[]>(`${API_ROUTES.PANEL.REQUEST}?idUser=2`)
      .pipe(
        map((r: IApiRequest[]) => {
          if (r.length > 0) {
            response.error = false;
            response.msg = `Se han encontrado ${r.length} solicitudes!`;
            response.data = r;
          } else if (r.length === 0) {
            response.error = false;
          }
          return response;
        }),
        catchError(e => {
          return of(response);
        })
      )
  }
}
