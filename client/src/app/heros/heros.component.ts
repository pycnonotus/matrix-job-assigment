import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { HerosService } from '../services/heros.service';
import { HeroCrateComponent } from './hero-crate/hero-crate.component';

@Component({
  selector: 'app-heros',
  templateUrl: './heros.component.html',
  styleUrls: ['./heros.component.css'],
})
export class HerosComponent implements OnInit {
  constructor(private dialog: MatDialog, public heroService: HerosService) {}

  ngOnInit(): void {
    this.heroService.loadHeros();
  }
  openCreateHeroDialog(): void {
    const dialogRef = this.dialog.open(HeroCrateComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
    });
  }
}
