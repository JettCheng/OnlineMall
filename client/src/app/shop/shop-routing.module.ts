import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ShopModule } from './shop.module';


const routes: Routes = [
  { path: '', component: ShopComponent },
  { path: ':id', component: ProductDetailComponent }
];

@NgModule({
  declarations: [],
  imports: [
    // CommonModule // 不需要這個
    RouterModule.forChild(routes) // 表示這個 module 無法再被 app.module 使用，儘可以被 shop.module 使用
  ],
  exports: [
    RouterModule
  ]
})
export class ShopRoutingModule { }
