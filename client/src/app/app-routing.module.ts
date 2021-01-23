import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './gurad/auth.guard';
import { HerosComponent } from './heros/heros.component';
import { LoginComponent } from './login/login.component';
import { NotlogedinHomeComponent } from './notlogedin-home/notlogedin-home.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', component: NotlogedinHomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'heros', component: HerosComponent, canActivate: [AuthGuard] },
  { path: '**', component: NotlogedinHomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
