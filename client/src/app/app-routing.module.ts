import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { NotlogedinHomeComponent } from './notlogedin-home/notlogedin-home.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', component: NotlogedinHomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
