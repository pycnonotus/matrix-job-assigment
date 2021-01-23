import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MartialBundleModule } from './martial-bundle/martial-bundle.module';
import { NotlogedinHomeComponent } from './notlogedin-home/notlogedin-home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HerosComponent } from './heros/heros.component';
import { HeroCrateComponent } from './heros/hero-crate/hero-crate.component';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { TimeagoModule } from 'ngx-timeago';

@NgModule({
  declarations: [
    AppComponent,
    NotlogedinHomeComponent,
    LoginComponent,
    RegisterComponent,
    HerosComponent,
    HeroCrateComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MartialBundleModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    TimeagoModule.forRoot(),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
