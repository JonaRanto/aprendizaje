import { Component, Input } from '@angular/core';
import { ROLES_ENUM } from '@data/enum';
import { ISidebarMenu } from '@data/interfaces';
import { AuthService } from '@data/services';

@Component({
  selector: 'app-sidebar-menu',
  templateUrl: './sidebar-menu.component.html',
  styleUrls: ['./sidebar-menu.component.scss']
})
export class SidebarMenuComponent {

  @Input() data: ISidebarMenu

  constructor(
    private authService: AuthService
  ) { }

  hasPermission(roles: ROLES_ENUM[]): boolean {
    if (roles) {
      return this.authService.hasAccessToModule(roles);
    }
    return true;
  }

}
