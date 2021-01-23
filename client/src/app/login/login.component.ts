import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit, OnDestroy {
  model = { username: '', password: '' };
  failedTry = false;
  subLogin = this.accountService.currentUser$.subscribe(
    (res) => {},
    (error) => {
      console.log(3);
      this.failedTry = true;
      this.loading = false;
    }
  );
  loading = false;

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
  }
  ngOnDestroy(): void {
    this.subLogin?.unsubscribe();
  }

  login(): void {

    console.log(1);
    // ;
    console.log(1.5);
    console.log('sub:' + this.subLogin.closed);


    this.loading = true;
    this.failedTry = false;
    this.accountService.login(this.model).subscribe(() => {
      //nav
    }, () => {
         this.loading = false;
         this.failedTry = true;
    });
  }
}
