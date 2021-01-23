import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Route, Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
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

  register(userRegister: {
    username: string;
    password: string;
  }): Observable<any> {
    const url = this.baseUrl + 'account/register';
    return this.http.post<User>(url, userRegister);
  }
  public login(user: { username: string; password: string }): Observable<any> {
    const url = this.baseUrl + 'account/login';
    return this.http.post<User>(url, user).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          this.setUser(user);
          this.router.navigate(['/heros']);
        }
      })
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
