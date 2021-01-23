import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  constructor(private accountService: AccountService, private router: Router) {}

  setCurrentUser(): void {
    const user: User = JSON.parse(localStorage.getItem('user')!);
    this.accountService.setUser(user);
    this.router.navigate(['/heros']);
  }
}
