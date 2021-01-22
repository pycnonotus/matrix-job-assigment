import { Component, OnInit } from '@angular/core';
import { User } from './model/user';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  ngOnInit(): void {
    this.setCurrentUser();
  }
  constructor(private accountService: AccountService) {}

  setCurrentUser(): void {
    const user: User = JSON.parse(localStorage.getItem('user')!);
    if (user) {
      this.accountService.setUser(user);
    }
  }
}
