import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Solicitud } from '../models/solicitud';
import { HttpClient } from '@angular/common/http';
import { Login } from '../models/login';
import { LoginResponse } from '../models/login-response';

@Injectable({
  providedIn: 'root'
})
export class SolicitudesService {

  constructor(private http:HttpClient) { }

  // loginByEmail(form:Login):Observable<Response>{
  //   let apiResponse = environment.apiControlVacaciones + "/usuarios"
  //   return this.http.post<Response>(apiResponse, form);
  // }}

  loginByEmail(form:Login):Observable<LoginResponse[]>{
    let apiResponse = environment.apiControlVacaciones + "/usuarios" + "?email=" + form.email + "&pass=" + form.pass  
    return this.http.get<LoginResponse[]>(apiResponse);
  }

  getSolicitudes(idUsuario:number):Observable<Solicitud[]>{
    let apiResponse = environment.apiControlVacaciones + "/solicitudes?idUsuario=" + idUsuario;
    return this.http.get<Solicitud[]>(apiResponse);
  }
}
