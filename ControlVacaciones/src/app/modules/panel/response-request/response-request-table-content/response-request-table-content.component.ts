import { Component, Input, OnInit } from '@angular/core';
import { IResponseRequestTableContent } from '@data/interfaces';

@Component({
  selector: 'app-response-request-table-content',
  templateUrl: './response-request-table-content.component.html',
  styleUrls: ['./response-request-table-content.component.scss']
})
export class ResponseRequestTableContentComponent implements OnInit {

  @Input() data: IResponseRequestTableContent;

  constructor() { }

  ngOnInit(): void {
  }

}
