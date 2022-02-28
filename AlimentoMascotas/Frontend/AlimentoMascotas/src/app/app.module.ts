import { LocationStrategy, PathLocationStrategy } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PrivateSkeletonComponent, PublicHeaderComponent, PublicSkeletonComponent } from './layouts';
import { PublicFooterComponent } from './layouts/public/public-footer/public-footer.component';

@NgModule({
  declarations: [
    AppComponent,
    PublicSkeletonComponent,
    PrivateSkeletonComponent,
    PublicHeaderComponent,
    PublicFooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    {
      provide: LocationStrategy,
      useClass: PathLocationStrategy,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
