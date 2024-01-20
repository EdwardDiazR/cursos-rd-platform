import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Course } from 'src/app/Models/course';
import { Teacher } from 'src/app/Models/teacher';
import { CourseService } from 'src/app/services/course/course.service';
import { TeacherService } from 'src/app/services/teacher/teacher.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-teacher-courses-list',
  templateUrl: './teacher-courses-list.component.html',
  styleUrls: ['./teacher-courses-list.component.css'],
})
export class TeacherCoursesListComponent implements OnInit {
  constructor(
    private _courseService: CourseService,
    private _teacherService: TeacherService
  ) {}

  @Input() teacherId!: number;
  @Input() teacher!: Teacher;
  TeacherCourses: Course[] = [];
  Top10Courses: Course[] = [];

  isLoading!: boolean;

  @Output() CoursesQuantity = new EventEmitter<number>();

  ngOnInit(): void {
    this.isLoading = true;
    this._courseService
      .GetCoursesByTeacherId(this.teacherId)
      .subscribe({
        next: (res)=>{      this.TeacherCourses = res;
        this.isLoading = false;
        this._courseService._teacherCoursesObservable.next(this.TeacherCourses);

        this.CoursesQuantity.emit(this.TeacherCourses.length);
        this.isLoading = false;
        // alert(this.TeacherCourses.length)}
      },error:(e)=>{
        this.isLoading = false;
      }});
   
  }
}
