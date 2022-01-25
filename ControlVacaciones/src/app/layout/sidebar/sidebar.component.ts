import { Component, OnInit } from '@angular/core';
import { INTERNAL_ROUTES } from '@data/constants/routes';
import { SIDEBAR_MENUS } from '@data/constants/sidebar-menu.const';
import { ISidebarMenu } from '@data/interfaces';
import { AuthService } from '@data/services';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  public name = 'Jona'
  public menus: ISidebarMenu[] = SIDEBAR_MENUS;
  public logoutMenu: ISidebarMenu;

  constructor(private authService: AuthService) { 
    this.logoutMenu = {
      title: '',
      links: [
        {
          name: 'Cerrar Sesión',
          link: INTERNAL_ROUTES.AUTH_LOGIN,
          method: () => this.authService.logout()
        }
      ]
    }
  }
  ngOnInit(): void {
  }

}
