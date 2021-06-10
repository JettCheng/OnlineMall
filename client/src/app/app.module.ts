import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { fromEventPattern } from 'rxjs';
import { CoreModule } from './core/core.module';
import { ShopModule } from './shop/shop.module';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CoreModule,
    // ShopModule // 已經不需要在一開始就 import 了，何時 import 的責任已經轉交給 shop.module
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
