import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Course, CourseDto } from 'src/app/Models/course';
import { environment } from 'src/app/environment';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CourseService {
  constructor(private http: HttpClient) {}

  teacherCourses!: Course[];
  selectedCourseDetails!: Course;

  public _teacherCoursesObservable: BehaviorSubject<Course[]> =
    new BehaviorSubject<Course[]>(this.teacherCourses);

  get _teacherCourses() {
    return this._teacherCoursesObservable.asObservable();
  }

  public _selectedCourseDetailsObservable: BehaviorSubject<Course> =
    new BehaviorSubject<Course>(this.selectedCourseDetails);

  get _selectedCourse() {
    return this._selectedCourseDetailsObservable.asObservable();
  }
  GetCoursesByTeacherId(TeacherId: number) {
    return this.http.get<any>(
      `${environment.apiUrl}/course/${TeacherId}/courses`
    );
  }

  CreateNewCourse(TeacherId: number, courseDto: CourseDto) {
    return this.http.post(
      `${environment.apiUrl}/course/${TeacherId}/create-course`,
      courseDto
    );
  }

  getCourseById(CourseId: string) {
    return this.http.get(`${environment.apiUrl}/course/${CourseId}/details`);
  }
}
