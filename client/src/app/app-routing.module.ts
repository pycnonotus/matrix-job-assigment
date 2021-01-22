import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HerosComponent } from './heros/heros.component';
import { LoginComponent } from './login/login.component';
import { NotlogedinHomeComponent } from './notlogedin-home/notlogedin-home.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', component: NotlogedinHomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'heros', component: HerosComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
