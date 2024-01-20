import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainCoursesComponent } from './main-courses.component';

describe('MainCoursesComponent', () => {
  let component: MainCoursesComponent;
  let fixture: ComponentFixture<MainCoursesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MainCoursesComponent]
    });
    fixture = TestBed.createComponent(MainCoursesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
