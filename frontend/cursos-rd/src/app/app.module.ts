import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TeacherProfilePageComponent } from './pages/teacher/teacher-profile-page/teacher-profile-page.component';
import { TeacherCoursesListComponent } from './components/course/teacher-courses-list/teacher-courses-list.component';
import { HttpClientModule } from '@angular/common/http';
import {  FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CourseService } from './services/course/course.service';
import { TeacherService } from './services/teacher/teacher.service';
import { CourseListItemComponent } from './components/course/course-list-item/course-list-item.component';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { MainCoursesComponent } from './pages/course/main-courses/main-courses.component';
import { TeacherFeedComponent } from './pages/teacher/teacher-feed/teacher-feed.component';
import { AccountVerificationAlertComponent } from './components/alerts/account-verification-alert/account-verification-alert.component';
import { NewCoursePageComponent } from './pages/course/new-course-page/new-course-page.component';
import { ProfileImageComponent } from './components/profile-image/profile-image.component';
import { ProfileInformationComponent } from './components/teacher/profile-information/profile-information.component';
import { SecuritySectionComponent } from './components/teacher/security-section/security-section.component';
import { CourseDetailsPageComponent } from './pages/course/course-details-page/course-details-page.component';

@NgModule({
  declarations: [
    AppComponent,
    CourseListItemComponent,
    TeacherProfilePageComponent,
    TeacherCoursesListComponent,
    NavBarComponent,
    MainCoursesComponent,
    TeacherFeedComponent,
    AccountVerificationAlertComponent,
    NewCoursePageComponent,
    ProfileImageComponent,
    ProfileInformationComponent,
    SecuritySectionComponent,
    CourseDetailsPageComponent,
    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    
    
    
  ],
  providers: [CourseService, TeacherService,FormsModule,ReactiveFormsModule],
  bootstrap: [AppComponent],
})
export class AppModule {}
