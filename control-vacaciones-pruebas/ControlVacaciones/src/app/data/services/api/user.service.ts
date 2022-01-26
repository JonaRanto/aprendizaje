import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiClass } from '@data/schema/ApiClass.class';
import { ICardUser } from '@shared/components'; 
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService extends ApiClass {

  constructor(http: HttpClient) {
    super(http);
  }

  /**
   * Get all users from api
   * @returns \{ error: boolean, msg: string, data: ICardUser[] }
   */
  getAllUsers(): Observable<{
    error: boolean,
    msg: string,
    data: ICardUser[]
  }> {
    const response = { error: false, msg: '', data: null };
    return this.http.get<ICardUser[]>(this.url + 'users')
    .pipe(
      map(r => {
        response.data = r;
        return response;
      }),
      catchError(this.error)
    );
  }

  /**
   * Get one user by id
   * @param id number
   * @returns \{ error: boolean, msg: string, data: ICardUser[] }
   */
  getUserById(id: number): Observable<{
    error: boolean,
    msg: string,
    data: ICardUser
  }> {
    const response = { error: false, msg: '', data: null };
    return this.http.get<ICardUser>(this.url + 'users/' + id)
    .pipe(
      map( r => {
        response.data = r;
        return response;
      }),
      catchError(this.error)
    );
  }
}
