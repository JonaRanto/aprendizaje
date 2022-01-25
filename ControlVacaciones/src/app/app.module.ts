import { LocationStrategy, PathLocationStrategy } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { SkeletonComponent } from './layout/skeleton/skeleton.component';
import { SidebarComponent } from './layout/sidebar/sidebar.component';
import { SidebarMenuComponent } from './layout/sidebar/sidebar-menu/sidebar-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    SkeletonComponent,
    SidebarComponent,
    SidebarMenuComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    SharedModule
  ],
  providers: [
    {
      provide: LocationStrategy,
      useClass: PathLocationStrategy
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
