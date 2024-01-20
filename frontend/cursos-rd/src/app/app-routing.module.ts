import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TeacherProfilePageComponent } from './pages/teacher/teacher-profile-page/teacher-profile-page.component';
import { LoginPageComponent } from './pages/user/login-page/login-page.component';
import { MainCoursesComponent } from './pages/course/main-courses/main-courses.component';
import { TeacherFeedComponent } from './pages/teacher/teacher-feed/teacher-feed.component';
import { NewCoursePageComponent } from './pages/course/new-course-page/new-course-page.component';
import { ProfileImageComponent } from './components/profile-image/profile-image.component';
import { ProfileInformationComponent } from './components/teacher/profile-information/profile-information.component';
import { SecuritySectionComponent } from './components/teacher/security-section/security-section.component';
import { CourseDetailsPageComponent } from './pages/course/course-details-page/course-details-page.component';

const routes: Routes = [
  // ****TODO: CREATE 404 ROUTE WITH PATH:{'**'} ****
  { path: '', pathMatch: 'full', redirectTo: 'login' },
  { path: 'login', component: LoginPageComponent },
  {
    path: 'teacher/:displayName',

    redirectTo: 'teacher/:displayName/feed',
  },
  {
    path: 'teacher/:displayName/feed',
    component: TeacherFeedComponent,
  },

  {
    path: 'teacher/:displayName/profile',
    component: TeacherProfilePageComponent,

    children: [
      { path: '', pathMatch: 'full', redirectTo: 'general' },
      {
        path: 'general',
        component: ProfileInformationComponent,
      },
      { path: 'security', component: SecuritySectionComponent },
    ],
  },

  {
    path: 'teacher/:teacherId/my-courses',
    component: MainCoursesComponent,
    pathMatch: 'full',
  },
  {
    path: 'teacher/:teacherDisplayName/my-courses/new',
    component: NewCoursePageComponent,
    pathMatch: 'full',
  },
  {
    path: 'course/:courseName',
    component: CourseDetailsPageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
  constructor() {}
}
