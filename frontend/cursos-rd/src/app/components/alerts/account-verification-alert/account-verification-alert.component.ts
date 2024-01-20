import { Component, Input, OnInit } from '@angular/core';
import { Teacher } from 'src/app/Models/teacher';

@Component({
  selector: 'app-account-verification-alert',
  templateUrl: './account-verification-alert.component.html',
  styleUrls: ['./account-verification-alert.component.css'],
})
export class AccountVerificationAlertComponent implements OnInit {
  @Input() teacher!: Teacher;
  showAlert!: boolean;
  @Input() showAccountConfirmationNotification!: boolean;

  ngOnInit(): void {
    this.showAlert = this.showAccountConfirmationNotification;
   
  }
  hideConfirmationAlert(): void {
    this.showAlert = false
    this.showAccountConfirmationNotification = false;
  }
}
