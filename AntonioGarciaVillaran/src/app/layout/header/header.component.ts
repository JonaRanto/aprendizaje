import { Component, OnInit } from '@angular/core';
import { HEADER_ICONS, HEADER_LOGO, HEADER_MENUS } from '@data/constants';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public logo = HEADER_LOGO
  public icons = HEADER_ICONS
  public menus = HEADER_MENUS

  constructor() {
    for (let menu of this.menus) {
      console.log(menu.subMenus)
    }
   }

  ngOnInit(): void {
  }

}
