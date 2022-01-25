import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-title-h4',
  templateUrl: './title-h4.component.html',
  styleUrls: ['./title-h4.component.css']
})
export class TitleH4Component implements OnInit {

  @Input() text = '';
  @Input() type: 'primary' | 'secondary' | 'success' | 'warning' | 'dark' = 'primary';
  
  constructor() { }

  ngOnInit(): void {
  }

}
