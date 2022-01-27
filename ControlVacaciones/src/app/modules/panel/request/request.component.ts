import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CONST_REQUESTS_PAGE } from '@data/constants/pages/requests/requests.const';
import { IApiResponse } from '@data/interfaces';
import { AuthService, RequestService } from '@data/services';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.scss']
})
export class RequestComponent {

  public data = CONST_REQUESTS_PAGE;
  public currentDate: string = null;
  public fromDate: string = null;
  public toDate: string = null;

  public requestForm: FormGroup;

  constructor(
    private requestService: RequestService,
    private authService: AuthService
  ) { 
    this.requestForm = this.data.REQUEST_FORM;
  }

  sendRequest() {
    console.log(this.fromDate, this.toDate, this.currentDate, this.requestForm.value.detail);
    // this.requestService.postRequest(
    //   this.authService.getUser.id,
    //   this.fromDate, this.toDate,
    //   this.currentDate,
    //   this.requestForm.value.detail)
    //   .subscribe((r: IApiResponse) => {
    //     console.log(r)
    //   })
  }

  eventEmitted(e) {
    this.fromDate = `${e[0].day}-${e[0].month}-${e[0].year}`;
    this.currentDate = `${e[2].day}-${e[2].month}-${e[2].year}`;
    if (e[1] != null){
      this.toDate = `${e[1].day}-${e[1].month}-${e[1].year}`;
    } else {
      this.toDate = null;
    }
  }
}
