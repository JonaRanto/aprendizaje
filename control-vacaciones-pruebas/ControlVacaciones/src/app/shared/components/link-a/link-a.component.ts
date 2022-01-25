import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-link-a',
  templateUrl: './link-a.component.html',
  styleUrls: ['./link-a.component.css']
})
export class LinkAComponent implements OnInit {

  @Input() text = '';
  @Input() type: 'primary' | 'secondary' | 'success' | 'warning' | 'dark' = 'primary';
  @Input() href: '/';

  constructor() { }

  ngOnInit(): void {
  }

}
