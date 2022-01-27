import { Component, Output } from '@angular/core';
import { NgbCalendar, NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-datepicker',
  templateUrl: './datepicker.component.html',
  styleUrls: ['./datepicker.component.scss']
})
export class DatepickerComponent {

  @Output() eventEmitter: EventEmitter<NgbDate[]> = new EventEmitter();

  hoveredDate: NgbDate | null = null;

  currentDate: NgbDate;
  fromDate: NgbDate;
  toDate: NgbDate | null = null;

  constructor(calendar: NgbCalendar) {
    this.currentDate = calendar.getToday();
    this.fromDate = null;//calendar.getToday();
    this.toDate = null;//calendar.getNext(calendar.getToday(), 'd', 0);
  }

  onDateSelection(date: NgbDate) {
    if (!this.fromDate && !this.toDate) {
      this.fromDate = date;
    } else if (this.fromDate && !this.toDate && date.after(this.fromDate)) {
      this.toDate = date;
    } else {
      this.toDate = null;
      this.fromDate = date;
    }
    this.eventEmitter.emit([this.fromDate, this.toDate, this.currentDate]);
  }

  isHovered(date: NgbDate) {
    return this.fromDate && !this.toDate && this.hoveredDate && date.after(this.fromDate) && date.before(this.hoveredDate);
  }

  isInside(date: NgbDate) {
    return this.toDate && date.after(this.fromDate) && date.before(this.toDate);
  }

  isRange(date: NgbDate) {
    return date.equals(this.fromDate) || (this.toDate && date.equals(this.toDate)) || this.isInside(date) || this.isHovered(date);
  }
}