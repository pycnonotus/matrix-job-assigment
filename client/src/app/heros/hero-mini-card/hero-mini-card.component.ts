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
}
