import { Component, OnInit } from '@angular/core';
import { SolicitudesService } from 'src/app/services/solicitudes.service';
import { Login } from 'src/app/models/login';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginResponse } from 'src/app/models/login-response';
import { Router } from '@angular/router';

@Component({
  selector: 'app-public-login',
  templateUrl: './public-login.component.html',
  styleUrls: ['./public-login.component.css']
})
export class PublicLoginComponent implements OnInit {

  loginForm = new FormGroup({
    email: new FormControl('', Validators.required),
    pass: new FormControl('', Validators.required)
  })

  constructor(private router:Router,private api:SolicitudesService) { }

  loginResponse:LoginResponse[];

  ngOnInit(): void {
  }

  onLogin(form:Login){
    this.api.loginByEmail(form).subscribe(data =>{
      this.loginResponse = data;
      if (data.length > 0){
        this.router.navigate(["private/historial-solicitudes"]);
      } 
      else {
        console.log("no");
      }
    })
  }
}
