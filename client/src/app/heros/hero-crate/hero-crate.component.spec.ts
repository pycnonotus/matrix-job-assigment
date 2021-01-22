import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeroCrateComponent } from './hero-crate.component';

describe('HeroCrateComponent', () => {
  let component: HeroCrateComponent;
  let fixture: ComponentFixture<HeroCrateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HeroCrateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeroCrateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
