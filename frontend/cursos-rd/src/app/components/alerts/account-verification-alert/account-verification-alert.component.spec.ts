import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountVerificationAlertComponent } from './account-verification-alert.component';

describe('AccountVerificationAlertComponent', () => {
  let component: AccountVerificationAlertComponent;
  let fixture: ComponentFixture<AccountVerificationAlertComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AccountVerificationAlertComponent]
    });
    fixture = TestBed.createComponent(AccountVerificationAlertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
