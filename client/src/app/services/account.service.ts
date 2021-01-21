import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../model/user';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  register(userRegister: { username: string; password: string }): void {
    const url = this.baseUrl + 'account/register';
    const observable = this.http.post<User>(url, userRegister).subscribe(
      (res) => {
        this.setUser(res);
      },
      (error) => {
        this.currentUserSource.error(error);
      }
    );
  }
  public login(user: { username: string; password: string }): void {
    const url = this.baseUrl + 'account/login';
    this.http.post<User>(url, user).subscribe((res) => {
      this.setUser(res);
    });
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
}
