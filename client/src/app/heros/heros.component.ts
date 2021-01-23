import {
  AfterViewInit,
  Component,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { Subscription, SubscriptionLike } from 'rxjs';
import { take } from 'rxjs/operators';
import { Hero } from '../model/hero';
import { AccountService } from '../services/account.service';
import { HerosService } from '../services/heros.service';
import { HeroCrateComponent } from './hero-crate/hero-crate.component';

@Component({
  selector: 'app-heros',
  templateUrl: './heros.component.html',
  styleUrls: ['./heros.component.css'],
})
export class HerosComponent implements AfterViewInit, OnDestroy, OnInit {
  heroData: Hero[] = [];
  dataSource: MatTableDataSource<Hero> | undefined;
  @ViewChild('matHero') heroTable: MatTable<any> | undefined;

  displayedColumns: string[] = [
    'name',
    'firstTraining',
    'suitColor',
    'startingPower',
    'curetPower',
    'trainedTodayTimes',
    'train',
  ];
  loading = true;
  loadingRequestTrain = false;
  private subHeros: Subscription | undefined;
  constructor(
    private dialog: MatDialog,
    public heroService: HerosService,
    private accountServices: AccountService
  ) {}
  ngOnDestroy(): void {
    this.subHeros?.unsubscribe();
  }
  ngOnInit(): void {
    this.subHeros = this.heroService.heros$.subscribe((res) => {

      this.heroData = res;
      if (this.heroTable) {
        this.heroTable.renderRows();
      }
      this.loading = false;
      this.loadingRequestTrain = false;
    });
  }
  ngAfterViewInit(): void {
    this.heroService.loadHeros();
  }
  openCreateHeroDialog(): void {
    const dialogRef = this.dialog.open(HeroCrateComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(result);
    });
  }
  logout(): void {
    this.accountServices.logout();
  }
  trainHero(heroId: string): void {
    this.loadingRequestTrain = true;
    this.heroService.trainHero(heroId);
  }
}
