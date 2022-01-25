import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-title-h3',
  templateUrl: './title-h3.component.html',
  styleUrls: ['./title-h3.component.css']
})
export class TitleH3Component implements OnInit {

  @Input() text = '';
  @Input() type: 'primary' | 'secondary' | 'success' | 'warning' | 'dark' = 'primary';

  constructor() { }

  ngOnInit(): void {
  }

}
