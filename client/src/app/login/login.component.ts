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
  subLogin: Subscription | undefined;

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    this.subLogin = this.accountService.currentUser$.subscribe(
      (res) => {},
      (error) => {
        this.failedTry = true;
      }
    );
  }
  ngOnDestroy(): void {
    this.subLogin?.unsubscribe();
  }
  login(): void {
    this.accountService.login(this.model);
  }
}
