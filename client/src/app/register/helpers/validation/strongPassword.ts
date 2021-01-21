import { AbstractControl, ValidatorFn } from '@angular/forms';

export function strongPassword(): ValidatorFn {
  return (control: AbstractControl) => {
    if (control == null) {
      return null;
    }
    console.log(control.value);

    const hasDigit = /(?=.*\d)/.test(control.value);
    const hasLower = /(?=.*[a-z])/.test(control.value);
    const hasUper = /(?=.*[A-Z])/.test(control.value);
    const hasNonAlphaNumeric = /(?=.*[-+_!@#$%^&*.,?])/.test(control.value);
    console.log({ hasDigit, hasLower, hasUper, hasNonAlphaNumeric });
    if (hasDigit && hasLower && hasUper && hasNonAlphaNumeric) {
      return null;
    }
    return { strongPassword: true };
  };
}
