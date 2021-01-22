import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeroMiniCardComponent } from './hero-mini-card.component';

describe('HeroMiniCardComponent', () => {
  let component: HeroMiniCardComponent;
  let fixture: ComponentFixture<HeroMiniCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeroMiniCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeroMiniCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
