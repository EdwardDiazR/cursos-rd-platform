import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Teacher } from 'src/app/Models/teacher';
import { User } from 'src/app/Models/user';
import { environment } from 'src/app/environment';
import { CourseService } from 'src/app/services/course/course.service';
import { TeacherService } from 'src/app/services/teacher/teacher.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-teacher-feed',
  templateUrl: './teacher-feed.component.html',
  styleUrls: ['./teacher-feed.component.css'],
})
export class TeacherFeedComponent {
  constructor(
    private _teacherService: TeacherService,
    private _authService: UserService,
    private _courseService: CourseService,
    private _router: Router
  ) {}
  teacher!: Teacher;
  teacherFullName!: string;
  teacherHasCourses!: boolean;
  
  user!: User;
  title = 'PROFILE';

  showAccountConfirmationNotification!: boolean;

  ngOnInit(): void {
    if (this._authService.CheckIsLogged()) {
      this.user = JSON.parse(
        sessionStorage.getItem(environment.localStorageUserKey)!
      ) as User;

      //Get the observable value of logged teacher
      this._teacherService._loggedTeacher.subscribe((res) => {
        if (res) {
          this.teacher = res;
          this.showAccountConfirmationNotification =
            !this.teacher.isEmailConfirmed;
        }

        this._courseService._teacherCourses.subscribe((courses) => {
          if (courses && courses.length) {
            this.teacherHasCourses = true;
          } else {
            this.teacherHasCourses = false;
          }
        });
      });
    } else {
      alert(
        'Ha ocurrido un error validando la sesion, inicia sesion nuevamente'
      );

      this._router.navigate(['/login']);
    }
  }

  hideConfirmationAlert(): void {
    this.showAccountConfirmationNotification = false;
  }


}
