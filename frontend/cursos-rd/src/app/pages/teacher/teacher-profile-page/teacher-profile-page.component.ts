import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { empty, map } from 'rxjs';
import { Teacher } from 'src/app/Models/teacher';
import { User } from 'src/app/Models/user';
import { environment } from 'src/app/environment';
import { TeacherService } from 'src/app/services/teacher/teacher.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-teacher-profile-page',
  templateUrl: './teacher-profile-page.component.html',
  styleUrls: ['./teacher-profile-page.component.css'],
})
export class TeacherProfilePageComponent implements OnInit {
  constructor(
    private _teacherService: TeacherService,
    private _authService: UserService,
    private _router: Router
  ) {}

  teacher!: Teacher;
  user!: User;
  showAccountConfirmationNotification!: boolean;

  ngOnInit(): void {
    if (this._authService.CheckIsLogged()) {
      this._teacherService._loggedTeacher.subscribe((res) => {
        this.teacher = res;
        console.log('Sin llamar a la API');
        this.showAccountConfirmationNotification = !res.isEmailConfirmed;
      });
    }
  }
}
