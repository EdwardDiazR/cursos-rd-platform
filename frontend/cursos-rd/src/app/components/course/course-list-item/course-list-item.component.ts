import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Course } from 'src/app/Models/course';
import { CourseService } from 'src/app/services/course/course.service';

@Component({
  selector: 'app-course-list-item',
  templateUrl: './course-list-item.component.html',
  styleUrls: ['./course-list-item.component.css'],
})
export class CourseListItemComponent implements OnInit {
  constructor(private _courseService: CourseService, private _router: Router) {}

  visibility!: string;
  courseDetailUrl!: string;

  @Input() Course!: Course;

  ngOnInit(): void {
    if (this.Course != null) {
      // console.log(this.Course);
      this.courseDetailUrl = '/course/' + this.Course.urlTitle;
      if (this.Course.isPublic == true) {
        this.visibility == 'Publico';
      } else {
        this.visibility == 'Privado';
      }
    }
  }

  getCourseDetail() {
    this._courseService.getCourseById(this.Course.id).subscribe({
      next: (res) => {
        console.log(res);
        this._courseService._selectedCourseDetailsObservable.next(
          res as Course
        );
        this._router.navigate([this.courseDetailUrl]);
      },
      error: (e) => console.log(e),
    });
  }
}
