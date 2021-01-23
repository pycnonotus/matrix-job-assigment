import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../services/account.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private accountService: AccountService, private router: Router) {}

  canActivate(): Observable<boolean> {
    console.log('here2');

    return this.accountService.currentUser$.pipe(
      map((user) => {
        console.log('here3');

        if (user) {
          console.log('here1');

          return true;
        } else {
          console.log('here');

          this.router.navigate(['/']);
          return false;
        }
      })
    );
  }
}
