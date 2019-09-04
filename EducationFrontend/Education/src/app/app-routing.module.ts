import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EducationEditComponent } from './Components/Education/education-edit/education-edit.component';
import { EducationListComponent } from './Components/Education/education-list/education-list.component';
import { EducationDetailsComponent } from './Components/Education/education-details/education-details.component';


const routes: Routes = [
  {path: 'education-list', component: EducationListComponent },
  {path: 'education-edit', component: EducationEditComponent },
  {path: 'education-edit/:id', component: EducationEditComponent },
  {path: 'education-details', component: EducationDetailsComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
