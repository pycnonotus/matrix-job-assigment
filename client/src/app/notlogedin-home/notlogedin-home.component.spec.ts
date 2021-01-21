import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotlogedinHomeComponent } from './notlogedin-home.component';

describe('NotlogedinHomeComponent', () => {
  let component: NotlogedinHomeComponent;
  let fixture: ComponentFixture<NotlogedinHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotlogedinHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NotlogedinHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
