import { Component, OnInit } from '@angular/core';
import { HEADER_LOGO, HEADER_MENUS } from '@data/constants';

@Component({
  selector: 'app-public-header',
  templateUrl: './public-header.component.html',
  styleUrls: ['./public-header.component.scss']
})
export class PublicHeaderComponent implements OnInit {

  public logo = HEADER_LOGO;
  public menus = HEADER_MENUS;

  constructor() { }

  ngOnInit(): void {
  }

}
