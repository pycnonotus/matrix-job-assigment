import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { matchValues } from 'src/app/register/helpers/validation/matchValues';
import { strongPassword } from 'src/app/register/helpers/validation/strongPassword';
import { HerosService } from 'src/app/services/heros.service';

@Component({
  templateUrl: './hero-crate.component.html',
  styleUrls: ['./hero-crate.component.css'],
})
export class HeroCrateComponent implements OnInit {
  addHeroForm = this.fb.group({
    name: ['', Validators.required],
    suitColor: ['', Validators.required],
    power: ['', Validators.required],
    ability: ['',  Validators.required],
  });
  loading = false;
  constructor(
    private fb: FormBuilder,
    private heroService: HerosService,
    public dialogRef: MatDialogRef<HeroCrateComponent>
  ) {}

  ngOnInit(): void {}
  onSubmit(): void {
    if (!this.addHeroForm.valid) {
      return;
    }
    this.loading = true;
    const name = this.addHeroForm.get('name')?.value;
    const suitColor = this.addHeroForm.get('suitColor')?.value;
    const power = this.addHeroForm.get('power')?.value;
    const ability = this.addHeroForm.get('ability')?.value;
    this.heroService.addHero({ name, suitColor, power, ability }).subscribe(() => {
          this.dialogRef.close();
    });
  }
}
