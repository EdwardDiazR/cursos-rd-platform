import { Component, OnInit } from '@angular/core';
import { Teacher } from 'src/app/Models/teacher';
import { User } from 'src/app/Models/user';
import { TeacherService } from 'src/app/services/teacher/teacher.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-main-courses',
  templateUrl: './main-courses.component.html',
  styleUrls: ['./main-courses.component.css'],
})
export class MainCoursesComponent implements OnInit {
  constructor(
    private _authService: UserService,
    private _teacherService: TeacherService
  ) {}

  _loggedUserInfo!: User;
  teacher!: Teacher;
  teacherCoursesQuantity:number= 0
  ngOnInit(): void {
    this._authService.loggedUserInfo.subscribe(
      (res) => (this._loggedUserInfo = res as User)
    );

    this._teacherService._loggedTeacher.subscribe((res) => {
      console.log(res);
      if (res) {
        console.log('hay res');
      } else {
        console.log('no hay res ' + this._loggedUserInfo.profileId);
        this._teacherService
          .getTeacherInfo(this._loggedUserInfo.profileId)
          .subscribe({
            next: (res) => {
              this.teacher = res as Teacher;
            },
          });
      }
      this.teacher = res;
    });
  }

  getCoursesQuantity(coursesQuantity:number){
    this.teacherCoursesQuantity = coursesQuantity
  }
}
