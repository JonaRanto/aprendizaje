import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { Login } from '../models/login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public currentUser: BehaviorSubject<Login>;
  public nameUserLocalStorage = 'currentUser';
  

  constructor( 
    private http: HttpClient,
    private router: Router
    ) { 
      this.currentUser = new BehaviorSubject(
        JSON.parse(localStorage.getItem(this.nameUserLocalStorage))
        );
    }

    get getUser(): Login{
      return this.currentUser.value;
    }

    login(
      data: {
        email: string;
        pass: string;
      }
    ):Observable <{
      error: boolean;
      message: string;
      data: any;
    }>
    response = {
      error: true,
      data: null
    };
}
