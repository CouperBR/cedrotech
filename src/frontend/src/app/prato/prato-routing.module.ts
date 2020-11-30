import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddPratoComponent } from './add-prato/add-prato.component';
import { ShowPratoComponent } from './show-prato/show-prato.component';

const routes: Routes = [
  { path: '', component: ShowPratoComponent},
  { path: 'add', component: AddPratoComponent},
  { path: 'update/:id', component: AddPratoComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PratoRoutingModule { }
