import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CONST_LOGIN_PAGE, ERRORS_VALIDATIONS } from '@data/constants'; 
import { IApiResponse } from '@data/interfaces';
import { AuthService } from '@data/services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  public data = CONST_LOGIN_PAGE;
  public errors_validations = ERRORS_VALIDATIONS;

  public loginForm: FormGroup;

  constructor(
    private authService: AuthService
  ) {
    this.loginForm = this.data.LOGIN_FORM;
  }

  authenticate() {
    console.log(this.loginForm.value)
    this.authService.login(this.loginForm.value).subscribe((r: IApiResponse) => {
      console.log(r)
    });
  }
}
