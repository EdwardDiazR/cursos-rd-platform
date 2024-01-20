import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Teacher } from 'src/app/Models/teacher';
import { User } from 'src/app/Models/user';
import { TeacherService } from 'src/app/services/teacher/teacher.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-profile-information',
  templateUrl: './profile-information.component.html',
  styleUrls: ['./profile-information.component.css'],
})
export class ProfileInformationComponent implements OnInit,OnChanges {
  teacher!: Teacher;
  user!: User;
  showAccountConfirmationNotification!: boolean;

  constructor(
    private _authService: UserService,
    private _teacherService: TeacherService
  ) {}

  ngOnInit(): void {
    if (this._authService.CheckIsLogged()) {
      this._teacherService._loggedTeacher.subscribe((res) => {
        this.teacher = res;
        console.log('Sin llamar a la API');
        this.showAccountConfirmationNotification =!this.teacher.isEmailConfirmed;
      });
      
    }

    console.log("showing info")
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log("changed")
  }
}
