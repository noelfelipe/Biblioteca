import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookCreateComponent } from './components/book-create/book-create.component';
import { EditBookComponent } from './components/book-update/book-update.component';
import { HomeComponent } from './home/home.component';
import { ListBookComponent } from './components/book-list/book-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'Home', pathMatch: 'full'},
  { path: 'Home', component: HomeComponent },
  { path: 'ListBook/:bookId', component: ListBookComponent },
  { path: 'BookCreate', component: BookCreateComponent },
  { path: 'EditBook/:bookId', component: EditBookComponent } 
];
  

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }