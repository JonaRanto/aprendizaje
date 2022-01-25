import { Component, Input, OnInit } from '@angular/core';
import { ISidebarMenu } from '@data/interfaces';

@Component({
  selector: 'app-sidebar-menu',
  templateUrl: './sidebar-menu.component.html',
  styleUrls: ['./sidebar-menu.component.scss']
})
export class SidebarMenuComponent implements OnInit {

  @Input() data: ISidebarMenu;

  constructor() { }

  ngOnInit(): void {
  }

}
