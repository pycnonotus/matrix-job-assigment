import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { Subscription } from 'rxjs';
import { AccountService } from '../services/account.service';
import { matchValues } from './helpers/validation/matchValues';
import { strongPassword } from './helpers/validation/strongPassword';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit, OnDestroy {
  registerForm = this.fb.group({
    username: ['', Validators.required],
    password: [
      '',
      [Validators.required, Validators.minLength(8), strongPassword()],
    ],
    confirmPassword: ['', [Validators.required, matchValues('password')]],
  });
  accountSubscription: Subscription | undefined;

  constructor(
    private fb: FormBuilder,
    private accountService: AccountService
  ) {}
  ngOnDestroy(): void {
    this.accountSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this.accountSubscription = this.accountService.currentUser$.subscribe(
      (user) => {},
      (error) => {
        console.log('here');
        console.log(error.error);

        if (error.error === 'This user already exists') {
          console.log('taken');

          this.registerForm.get('username')?.setErrors({ userTaken: true });
        }
      }
    );
  }

  onSubmit() {
    console.log(this.registerForm);
    if (!this.registerForm.valid) {
      return;
    }
    const username = this.registerForm.get('username')?.value;
    const password = this.registerForm.get('password')?.value;
    const user = {
      username,
      password,
    };
    this.accountService.register(user);
  }
}
