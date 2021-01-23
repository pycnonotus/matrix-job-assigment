import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Route, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../model/user';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private router: Router) {}
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  register(userRegister: { username: string; password: string }): void {
    const url = this.baseUrl + 'account/register';
    const observable = this.http.post<User>(url, userRegister).subscribe(
      (res) => {
        this.setUser(res);
        this.router.navigate(['/heros']);
      },
      (error) => {
        this.currentUserSource.error(error);
      }
    );
  }
  public login(user: { username: string; password: string }): void {
    const url = this.baseUrl + 'account/login';
    this.http.post<User>(url, user).subscribe(
      (res) => {
        this.setUser(res);
        this.router.navigate(['/heros']);
      },
      (error) => {
        console.log('failed to login');

        this.currentUserSource.error(error);
      }
    );
  }

  public setUser(user: User): void {
    if (user != null) {
      const decode = this.getDecodedToken(user.token);
      user.username = decode.unique_name;
    }
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }
  private getDecodedToken(token: string): any {
    return JSON.parse(atob(token.split('.')[1]));
  }
  logout(): void {
    localStorage.removeItem('user');
    this.currentUserSource.next(null!);
    this.router.navigate(['/']);
  }
}
