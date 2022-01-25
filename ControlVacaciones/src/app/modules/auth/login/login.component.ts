import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CONST_LOGIN_PAGE, ERRORS_VALIDATIONS } from '@data/constants'; 
import { AuthService } from '@data/services/api/auth.service';

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
    this.authService.login(this.loginForm.value).subscribe(r => {
      console.log(r)
    });
  }
}
