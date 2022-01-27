import { Component, OnInit } from '@angular/core';
import { IApiRequest, IApiResponse, IResponseRequestTableContent } from '@data/interfaces';
import { RequestService } from '@data/services';

@Component({
  selector: 'app-response-request',
  templateUrl: './response-request.component.html',
  styleUrls: ['./response-request.component.scss']
})
export class ResponseRequestComponent implements OnInit {

  public tableContent: IResponseRequestTableContent[] = [];
  public apiRequest: IApiRequest[] = [];

  constructor(
    private requesService: RequestService
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

  ngOnInit(): void {
    
  }

}
