import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PratoRoutingModule } from './prato-routing.module';
import { ShowPratoComponent } from './show-prato/show-prato.component';
import { AddPratoComponent } from './add-prato/add-prato.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [ShowPratoComponent, AddPratoComponent],
  imports: [
    CommonModule,
    PratoRoutingModule,
    FormsModule
  ]
})
export class PratoModule { }
