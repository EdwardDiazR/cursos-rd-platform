import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Course } from 'src/app/Models/course';
import { CourseService } from 'src/app/services/course/course.service';

@Component({
  selector: 'app-course-details-page',
  templateUrl: './course-details-page.component.html',
  styleUrls: ['./course-details-page.component.css'],
})
export class CourseDetailsPageComponent implements OnInit, OnDestroy {
  course!: Course;
  id!: string;
  // url:string = this.route.snapshot.paramMap.get('id');
  constructor(
    private _courseService: CourseService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.id=this.route.snapshot.paramMap.get('courseName')|| '' ;
    // this.route.snapshot.
    // this.route.queryParams.subscribe((e) => {
    //   console.log(e);
    //   this.id = e['course'];
    // });
    this.route.queryParamMap.subscribe((params) => console.log(params));
    this._courseService._selectedCourse.subscribe({
      next: (res) => {
        if (!res) {
          //TODO: CALL API FOR COURSE DETAILS

          this._courseService
            .getCourseById(this.id)
            .subscribe({ next: (res) => (this.course = res as Course) });
        }
        this.course = res;
      },
      error: (e) => alert(e),
    });

    console.log(this.course);
  }

  ngOnDestroy(): void {
    this._courseService._selectedCourseDetailsObservable.next(this.course);
  }
}
