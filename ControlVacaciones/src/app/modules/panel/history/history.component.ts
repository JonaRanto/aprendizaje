import { Component, OnInit } from '@angular/core';
import { IApiRequest, IApiResponse } from '@data/interfaces';
import { AuthService } from '@data/services';
import { RequestService } from '@data/services';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss']
})
export class HistoryComponent implements OnInit {

  public apiRequest: IApiRequest[] = [];

  constructor(
    private requestService: RequestService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.requestService.getRequestsFromUser(this.authService.getUser.id)
      .subscribe((r: IApiResponse) => {
        if (r.data) { // Evitar error de slice al enviar un valor nulo
          this.apiRequest = r.data.slice().reverse();
        }
      });
  }

}
