import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ERRORS_CONST } from '@data/constants';
import { API_ROUTES } from '@data/constants/routes';
import { IApiResponse, IApiRequest, IApiUserAuthenticate } from '@data/interfaces';
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
    return this.http.get<IApiRequest[]>(`${API_ROUTES.PANEL.REQUEST}?idUser=${idUser}`)
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
        catchError(_ => {
          return of(response);
        })
      )
  }

  postRequest(
    idUser: number,
    fromDate: string,
    toDate: string,
    currentDate: string,
    detail: string
  ): Observable<IApiResponse> {
    const response = { error: true, msg: ERRORS_CONST.REQUEST.REQUEST_ERROR, data: null };
    let data: IApiRequest = {
      id: null,
      requestDate: currentDate,
      departureDate: fromDate,
      returnDate: toDate,
      detail: detail,
      state: 'Pendiente',
      idUser: idUser
    };
    return this.http.post<IApiRequest>(`${API_ROUTES.PANEL.REQUEST}`, data)
      .pipe(
        map(_ => {
          response.error = false;
          response.msg = 'Se ha realizado la solicitud correctamente!';
          response.data = data;
          return response;
        }),
        catchError(_ => {
          return of(response);
        })
      )
  }

  getRequests(): Observable<IApiResponse> {
    const response = { error: true, msg: ERRORS_CONST.REQUEST.REQUESTS_NOT_FOUND, data: null };
    return this.http.get<IApiRequest[]>(`${API_ROUTES.PANEL.REQUEST}`)
      .pipe(
        map((r: IApiRequest[]) => {
          response.error = false;
          response.msg = `Se han encontrado ${r.length} solicitudes!`;
          response.data = r;
          return response;
        }),
        catchError(_ => {
          return of(response);
        })
      )
  }

  getNameUserById(idUser: number): Observable<IApiResponse> {
    const response = { error: true, msg: ERRORS_CONST.REQUEST.REQUESTS_NOT_FOUND, data: null };
    return this.http.get<IApiUserAuthenticate[]>(`${API_ROUTES.AUTH.LOGIN}?id=${idUser}`)
      .pipe(
        map((r: IApiUserAuthenticate[]) => {
          response.error = false;
          response.msg = 'Se ha realizado la solicitud correctamente!';
          response.data = r[0].name;
          return response;
        }),
        catchError(_ => {
          return of(response);
        })
      )
  }
}
