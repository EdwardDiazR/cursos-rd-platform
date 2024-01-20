import { Component } from '@angular/core';

@Component({
  selector: 'app-security-section',
  templateUrl: './security-section.component.html',
  styleUrls: ['./security-section.component.css'],
})
export class SecuritySectionComponent {
  
  changePassword(): void {
    //TODO: Create 'Change password'  API & Methods
  }

  discardChangePassword(): void {
    //TODO: Discard & clear change password's inputs
  }
}
