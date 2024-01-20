import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { CourseDto } from 'src/app/Models/course';
import { Teacher } from 'src/app/Models/teacher';
import { CourseService } from 'src/app/services/course/course.service';
import { TeacherService } from 'src/app/services/teacher/teacher.service';

@Component({
  selector: 'app-new-course-page',
  templateUrl: './new-course-page.component.html',
  styleUrls: ['./new-course-page.component.css'],
})
export class NewCoursePageComponent implements OnInit {
  todaysDate: Date = new Date();
  courseForm!: FormGroup;
  courseDto!: CourseDto;
  Teacher!: Teacher;

  //Keywords variables
  titleKeywords: string[] = [];
  urlTitlePreview!: string;
  disableWriteMoreKeywords!: number;
  containsSpecialCharacters: boolean = false;
  ib!: string;

  firstKeyword!: string;
  secondKeyword!: string;
  thirdKeyword!: string;
  fourthKeyword!: string;

  maximumKewordsAllowed: number = 4;

  constructor(
    private _courseService: CourseService,
    private _teacherService: TeacherService,
    private titleService:Title
  ) {}

  ngOnInit(): void {

    this.titleService.setTitle('Agregar nuevo curso')
    this._teacherService._loggedTeacher.subscribe(
      (res) => (this.Teacher = res)
    );

    this.courseForm = new FormGroup({
      courseName: new FormControl('', Validators.required),
      courseDescription: new FormControl(''),
      coursePrice: new FormControl(0, [Validators.required, Validators.min(1)]),
      publishedDate: new FormControl(this.todaysDate, Validators.required),
      courseLanguage: new FormControl('', Validators.required),
      // titleKeywords: new FormControl('', [
      //   Validators.required,
      //   Validators.minLength(4),
      //   Validators.pattern('[a-z A-z 0-9]*'),
      // ]),

      firstKeyword: new FormControl('', [
        Validators.required,
        Validators.pattern('[a-z A-z 0-9]*'),
      ]),
      secondKeyword: new FormControl('', [
        Validators.required,
        Validators.pattern('[a-z A-z 0-9]*'),
      ]),
      thirdKeyword: new FormControl('', [
        Validators.required,
        Validators.pattern('[a-z A-z 0-9]*'),
      ]),
      fourthKeyword: new FormControl('', [
        Validators.required,
        Validators.pattern('[a-z A-z 0-9]*'),
      ]),
    });
    console.log(this.courseForm.value);
  }

  setKeyword() {
    this.firstKeyword = this.courseForm.get('firstKeyword')?.value || '';
    this.secondKeyword = this.courseForm.get('secondKeyword')?.value || '';
    this.thirdKeyword = this.courseForm.get('thirdKeyword')?.value || '';
    this.fourthKeyword = this.courseForm.get('fourthKeyword')?.value || '';

    //TODO: Transform the keywords

    this.titleKeywords = [
      this.firstKeyword.trimEnd().replace(' ','-'),
      this.secondKeyword.trimEnd().replace(' ','-'),
      this.thirdKeyword.trimEnd().replace(' ','-'),
      this.fourthKeyword.trimEnd().replace(' ','-'),
    ];
    this.urlTitlePreview = `${this.firstKeyword + '-' + this.secondKeyword + '-' + this.thirdKeyword + '-' + this.fourthKeyword}`

    console.log(this.courseForm.value);
  }
  publishDateValidator(form: FormGroup): boolean {
    const publishDate = new Date(form.get('publishedDate')?.value);
    const dateIsValid = publishDate >= this.todaysDate;
    return dateIsValid;
  }

  createCourse() {
    console.log(this.courseForm.value);

    if (this.publishDateValidator(this.courseForm) && this.courseForm.valid) {
      this.courseDto = <CourseDto>{
        Name: this.courseForm.get('courseName')?.value || '',
        Description: this.courseForm.get('courseDescription')?.value || ' ',
        Price: this.courseForm.get('coursePrice')?.value || 0,
        PublishedDate:
          this.courseForm.get('publishedDate')?.value || this.todaysDate,
        Language: this.courseForm.get('courseLanguage')?.value || '',
        TitleKeywords: this.titleKeywords,
        TeacherId: this.Teacher.id,
      };

      this._courseService
        .CreateNewCourse(this.Teacher.id, this.courseDto)
        .subscribe({
          next: (res) => {
            console.log(res);
          },
          error: (e) => {
            alert(e.error);
            console.log(e);
          },
        });
      console.log(this.courseDto);
    }
  }

  checkIfUrlIsAvailable() {}

  getUrlTitlePreview(kewords: string) {
    this.disableWriteMoreKeywords = 500;
    this.urlTitlePreview = kewords.trimEnd().replaceAll(' ', '-');
    var prev = this.urlTitlePreview.split('-');
    this.ib = kewords;
    console.log('preview => ' + this.urlTitlePreview);
    console.log(this.titleKeywords.length);

    this.titleKeywords[prev.length - 1] = prev[prev.length - 1];

    var lastIndexOfKeywords = this.titleKeywords[prev.length - 1];

    var lastIndexOfPrev = this.titleKeywords[prev.length - 1];

    console.log(this.titleKeywords);
    prev.forEach((element, i) => {
      this.titleKeywords[i] = element;
    });

    if (prev.length < this.titleKeywords.length) {
      this.titleKeywords.pop();
    }
    if (kewords.length == 0) {
      this.titleKeywords = [];
    }

    if (this.checkIfKewordHasCharacter(kewords)) {
      this.containsSpecialCharacters = true;
      this.disableWriteMoreKeywords = this.ib.length;
    } else {
      this.containsSpecialCharacters = false;
    }

    console.log(this.courseForm.value);
  }

  agregarKeyword() {
    this.titleKeywords.push(this.ib);
    this.ib = '';
  }
  removeKeyword(index: number) {
    this.titleKeywords.splice(index);
  }
  //Method for block user's keywords input when reached maximum keywords allowed
  show() {
    if (this.titleKeywords.length == this.maximumKewordsAllowed) {
      this.disableWriteMoreKeywords = this.ib.length;
    }
  }

  checkIfKewordHasCharacter(keywords: string): boolean {
    if (keywords.includes('#')) {
      return true;
    } else {
      return false;
    }
  }
}
