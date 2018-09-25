import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './share/components/header/header.component';
import { CarouselComponent } from './share/components/carousel/carousel.component';
import { MenubarComponent } from './share/components/header/menubar/menubar.component';
import { MemberbarComponent } from './share/components/header/memberbar/memberbar.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    CarouselComponent,
    MenubarComponent,
    MemberbarComponent
  ],
  imports: [
    BrowserModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
