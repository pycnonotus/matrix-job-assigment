import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(private accountService: AccountService) {}
  model = { username: '', password: '' };
  ngOnInit(): void {}

  login() {
    this.accountService.login(this.model);
  }
}
