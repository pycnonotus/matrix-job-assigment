import { Component, Input, OnInit } from '@angular/core';
import { Hero } from 'src/app/model/hero';

@Component({
  selector: 'app-hero-mini-card',
  templateUrl: './hero-mini-card.component.html',
  styleUrls: ['./hero-mini-card.component.css'],
})
export class HeroMiniCardComponent implements OnInit {
  @Input() hero: Hero | undefined;
  constructor() {}

  ngOnInit(): void {}
  getTrainDateString() {
    return this.hero!.firstTrained === null ||
      this.hero!.firstTrained === undefined
      ? 'Hero has not yet trained'
      : this.dateString();
  }
  private dateString() {
    return (
      this.hero!.firstTrained!.getDay() +
      '/' +
      this.hero!.firstTrained!.getMonth() +
      '/' +
      this.hero!.firstTrained!.getFullYear()
    );
  }
}
