import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './components/text-input/text-input.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';


@NgModule({
  declarations: [
    TextInputComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    AccordionModule.forRoot(),
    BsDropdownModule.forRoot()
  ],
  exports: [
    PaginationModule,
    AccordionModule,
    ReactiveFormsModule,
    TextInputComponent,
    BsDropdownModule
  ]
})
export class SharedModule { }
