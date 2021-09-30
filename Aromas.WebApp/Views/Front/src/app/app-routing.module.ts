import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListUserComponent } from './components/views/user/list-user/list-user.component';
import { RegisterUserComponent } from './components/views/user/register-user/register-user.component';

const routes: Routes = [
  { path: '', component: RegisterUserComponent},
  { path: 'list', component: ListUserComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
