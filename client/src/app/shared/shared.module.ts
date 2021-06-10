import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { AccordionModule } from 'ngx-bootstrap/accordion';


@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    AccordionModule.forRoot(),
  ],
  exports: [
    PaginationModule,
    AccordionModule
  ]
})
export class SharedModule { }
