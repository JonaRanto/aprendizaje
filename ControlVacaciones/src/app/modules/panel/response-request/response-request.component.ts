import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { INTERNAL_ROUTES } from '@data/constants/routes';
import { IApiRequest, IApiResponse, IResponseRequestTableContent } from '@data/interfaces';
import { RequestService } from '@data/services';

@Component({
  selector: 'app-response-request',
  templateUrl: './response-request.component.html',
  styleUrls: ['./response-request.component.scss']
})
export class ResponseRequestComponent {

  public tableContent: IResponseRequestTableContent[] = [];
  public apiRequest: IApiRequest[] = [];

  constructor(
    private requesService: RequestService,
    private router: Router
    ) {
    this.requesService.getRequests()
      .subscribe((r: IApiResponse) => {
        this.apiRequest = r.data.slice().reverse();
        for (let i = 0; i < this.apiRequest.length; i++) {
          this.requesService.getNameUserById(this.apiRequest[i].idUser).subscribe((r: IApiResponse) => { 
            this.tableContent.push({
              id: this.apiRequest[i].id,
              employee: r.data,
              requestDate: this.apiRequest[i].requestDate,
              departureDate: this.apiRequest[i].departureDate,
              returnDate: this.apiRequest[i].returnDate,
              detail: this.apiRequest[i].detail,
              state: this.apiRequest[i].state
            });
           });
        };
      });
  }

  eventEmitted(e: Event): void {
    if (e[0][0] === 'Aceptar') {
      this.acceptRequest(e[0][1]);
    }
    if (e[0][0] === 'Rechazar') {
      this.deleteRequest(e[0][1]);
    }
  }

  acceptRequest(idRequest: number): void {
    this.requesService.getRequestById(idRequest)
      .subscribe((r: IApiResponse) => {
        r.data.state = "Aceptada";
        this.requesService.updateRequest(r.data)
          .subscribe((r: IApiResponse) => {
            console.log(r.msg);
            this.router.navigateByUrl('/',
            {skipLocationChange: true}).then(()=> 
            this.router.navigate([INTERNAL_ROUTES.PANEL_RESPONSES]));
          })
      })
  }

  deleteRequest(idRequest: number): void {
    this.requesService.getRequestById(idRequest)
      .subscribe((r: IApiResponse) => {
        r.data.state = "Rechazada";
        this.requesService.updateRequest(r.data)
          .subscribe((r: IApiResponse) => {
            console.log(r.msg);
            this.router.navigateByUrl('/',
            {skipLocationChange: true}).then(()=> 
            this.router.navigate([INTERNAL_ROUTES.PANEL_RESPONSES]));
          })
      })
  }
  
}
