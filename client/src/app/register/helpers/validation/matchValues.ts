import { AbstractControl, ValidatorFn } from '@angular/forms';

export function matchValues(matchTo: string): ValidatorFn {
  return (control: AbstractControl) => { //TODO Fix bug if user types filed in difret order
    if (matchTo === null || matchTo === '') {
      return null;
    }
    console.log(
      control?.value,
      (control?.parent as any)?.controls[matchTo]?.value,
      matchTo
    );

    return control?.value === (control?.parent as any)?.controls[matchTo]?.value // this is a work around, ts thinks control[string] is not vaild
      ? null
      : { isMatching: true };
  };
}
