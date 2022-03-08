import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IApiResponse } from '@data/interfaces';
import { catchError, map, Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AlimentoService {

  filterParams: any = {};

  constructor(
    private http: HttpClient,
  ) {
    this.filterParams = {};
    // Se llenan los filtros con la información de sessionStorage y con estos se rellena una variable json para pasarlos a queryParam
    var key = sessionStorage.getItem('filters');
    for (let filter of (key == null ? "" : key).split(',')) {
      var arrKey = filter.split(': ')[0];
      var arrValue = filter.split(': ')[1];
      this.filterParams[arrKey] = arrValue;
    }
  }

  getAlimentos(endPoint: string, defaultError: string): Observable<IApiResponse> {
    const response = {
      error: true,
      message: defaultError,
      data: null,
    }
    return this.http.get<IApiResponse>(endPoint, { params: this.filterParams })
    .pipe(
      map((r: IApiResponse) => {
        response.error = r.error;
        response.message = r.message;
        response.data = r.data;
        return response;
      }),
      catchError(_ => {
        console.log(_.status);
        return of(response);
      })
    )
  }
}
