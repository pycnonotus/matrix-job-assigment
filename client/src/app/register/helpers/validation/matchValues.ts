import { AbstractControl, ValidatorFn } from '@angular/forms';

export function matchValues(matchTo: string): ValidatorFn {
  return (control: AbstractControl) => {
    if (matchTo === null || matchTo === '') {
      return null;
    }
    return control?.value === (control?.parent as any)?.controls[matchTo]?.value // this is a work around, ts thinks control[string] is not vaild
      ? null
      : { isMatching: true };
  };
}
