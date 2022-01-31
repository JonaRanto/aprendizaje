import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ERRORS_VALIDATIONS } from '@data/constants';
import { CONST_REQUESTS_PAGE } from '@data/constants'; 
import { ROUTES_PATHS } from '@data/constants/routes';
import { IApiResponse } from '@data/interfaces';
import { AuthService, RequestService } from '@data/services';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.scss']
})
export class RequestComponent {

  public data = CONST_REQUESTS_PAGE;
  public errors_validations = ERRORS_VALIDATIONS;
  public currentDate: string = null;
  public fromDate: string = null;
  public toDate: string = null;

  public requestForm: FormGroup;

  constructor(
    private requestService: RequestService,
    private authService: AuthService,
    private router: Router
  ) { 
    this.requestForm = this.data.REQUEST_FORM;
  }

  sendRequest() {
    if (this.fromDate != null && this.toDate === null){ 
      this.toDate = this.fromDate;
    }
    this.requestService.postRequest(
      this.authService.getUser.id,
      this.fromDate,
      this.toDate,
      this.currentDate,
      this.requestForm.value.detail)
      .subscribe((r: IApiResponse) => {
        console.log(r)
        if (!r.error) {
          this.router.navigateByUrl(ROUTES_PATHS.PANEL.HISTORY);
        }
      })
  }

  eventEmitted(e: NgbDate[]) {
    this.fromDate = `${e[0].day}-${e[0].month}-${e[0].year}`;
    this.currentDate = `${e[2].day}-${e[2].month}-${e[2].year}`;
    if (e[1] != null){
      this.toDate = `${e[1].day}-${e[1].month}-${e[1].year}`;
    } else {
      this.toDate = null;
    }
  }

  get requestValidated() {
    if (!this.dateRangeValidated && !this.requestForm.invalid) {
      return false;
    }
    return true;
  }

  get dateRangeValidated() {
    if (this.fromDate != null
    && this.currentDate != null) {
      return false;
    }
    return true;
  }
}
