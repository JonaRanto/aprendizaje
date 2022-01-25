import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ERRORS_CONST } from '@data/constants';
import { API_ROUTES, INTERNAL_ROUTES } from '@data/constants/routes';
import { IApiResponse, IApiUserAuthenticate } from '@data/interfaces';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map, catchError, find } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public currentUser: BehaviorSubject<IApiUserAuthenticate>;  // Se establece el tipo del BehaviorSubject
  public nameUserLS = 'currentUser';  // Nombre del almacenamiento local qu e se utilizará para guardar la información del usuario

  constructor(
    private http: HttpClient,
    private router: Router
  ) {
    this.currentUser = new BehaviorSubject(
      JSON.parse(localStorage.getItem(this.nameUserLS)) // Se guardan los datos solo del usuario actual
    );
  }

  get getUser(): IApiUserAuthenticate {
    return this.currentUser.value;    // Metodo que devuelve el valor del usuario actual
  }

  /**
   * 
   * @param data: { email: string, pass: string }
   * @returns Observable\<IApiResponse>
   */
  login(
    data: {
      email: string,
      pass: string
    }
  ): Observable<IApiResponse> {
    const response = { error: true, msg: ERRORS_CONST.LOGIN.USER_NOT_FOUND, data: null }; // La respuesta se inicializa con un valor de error por defecto y sin datos
    return this.http.get<IApiUserAuthenticate[]>(`${API_ROUTES.AUTH.LOGIN}?email=${data.email}&pass=${data.pass}`)  // Se hace un get con el tipo de la respuesta a la url
    .pipe(  // Aceptar el observable y se suscribe automaticamente (observable: Obtiene los datos una vez se hayan cargado sin intentarlo antesde que carguen)
      map(r => {  // Map obtiene un observable como entrada, aplica una funciona los valores emitidos por el observable y los transforma en un nuevo valor
        if (r.length === 1) {
          response.error = false;
          response.msg = 'Autenticación correcta!';
          response.data = r[0];
          this.setUserToLocalStorage(response.data); // Setea el user en el LocalStorage
          this.currentUser.next(response.data);  // Deja el usuario actual con lo obtenido en data
        }
        if (!response.error) {
          this.router.navigateByUrl(INTERNAL_ROUTES.PANEL_HISTORY);
        }
        return response;
      }),
      catchError(e => {       // catchError se lanza en caso de que hayan errores en el observable, los captura y devuelve un error
        return of(response);  // La funcion of crea una lista de elementos
      })
    );
  }

  logout() {
    localStorage.removeItem(this.nameUserLS); // Quita el user dentro del LocalStorage indicado mediante el nombre del almacenamiento local
    this.currentUser.next(null);  // Deja el usuario actual como nulo
    this.router.navigateByUrl(INTERNAL_ROUTES.AUTH_LOGIN);  // Redirige hacia la ventana de login
  }

  private setUserToLocalStorage(user: IApiUserAuthenticate) {
    localStorage.setItem(this.nameUserLS, JSON.stringify(user));    // Setea el user recibido dentro del LocalStorage indicado mediante el nombre del almacenamiento local
  }
}
