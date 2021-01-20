import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlaneBoardComponent } from './plane-board.component';

describe('PlaneBoardComponent', () => {
  let component: PlaneBoardComponent;
  let fixture: ComponentFixture<PlaneBoardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlaneBoardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlaneBoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
