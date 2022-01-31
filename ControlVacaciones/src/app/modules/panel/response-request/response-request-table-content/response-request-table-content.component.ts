import { Component, Input, OnInit, Output } from '@angular/core';
import { IResponseRequestTableContent } from '@data/interfaces';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-response-request-table-content',
  templateUrl: './response-request-table-content.component.html',
  styleUrls: ['./response-request-table-content.component.scss']
})
export class ResponseRequestTableContentComponent {

  @Input() data: IResponseRequestTableContent;
  @Output() eventEmitter: EventEmitter<[string, number]> = new EventEmitter();

  actionSelection(action: string, idRequest: number): void {
    this.eventEmitter.emit([action, idRequest]);
  }

}
