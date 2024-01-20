import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { User } from 'src/app/Models/user';
import { environment } from 'src/app/environment';
import { TeacherService } from '../teacher/teacher.service';
import { Teacher } from 'src/app/Models/teacher';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  loggedUser!: User;
  teacher!: Teacher;

  private _loggedTeacherObservable: BehaviorSubject<Teacher> =
    new BehaviorSubject<Teacher>(this.teacher);

  private _isLoggedObservable: BehaviorSubject<boolean> =
    new BehaviorSubject<boolean>(false);

  private _loggedUserObservable: BehaviorSubject<User> =
    new BehaviorSubject<User>(this.loggedUser);

  private _logged: BehaviorSubject<User> = new BehaviorSubject<User>(
    this.loggedUser
  );

  private _WrongCredentialsObservable: BehaviorSubject<boolean> =
    new BehaviorSubject<boolean>(false);

  constructor(
    private _http: HttpClient,
    private _router: Router,
    private _teacherService: TeacherService
  ) {}

  CheckIsLogged(): boolean {
    if (sessionStorage.getItem('currentUser')) {
      this.loggedUser = JSON.parse(
        sessionStorage.getItem('currentUser') || ''
      ) as User;
      this._loggedUserObservable.next(this.loggedUser);
      this._isLoggedObservable.next(true);

      return true;
    } else {
      this._isLoggedObservable.next(false);
      sessionStorage.removeItem('currentUser');
      return false;
    }
  }

  get isLogged() {
    return this._isLoggedObservable.asObservable();
  }

  get loggedUserInfo() {
    return this._loggedUserObservable.asObservable();
  }

  get _loggedTeacherProfile() {
    return this._loggedTeacherObservable.asObservable();
  }

  get _EnteredWrongCredentials() {
    return this._WrongCredentialsObservable.asObservable();
  }

  login(email: string, password: string) {
    console.log('Servicio login llamado');

    this._http
      .post(`${environment.apiUrl}/user/login`, {
        Email: email,
        Password: password,
      })

      .subscribe({
        next: (user) => {
          this._WrongCredentialsObservable.next(false);
          this.loggedUser = user as User;
          var u = user as User;
          console.log(u);

          if (u.roleId == 1) {
            this._teacherService
              .getTeacherInfo(this.loggedUser.profileId)

              .subscribe((res) => {
                this._isLoggedObservable.next(true);
                this._loggedUserObservable.next(this.loggedUser);

                sessionStorage.setItem(
                  'currentUser',
                  JSON.stringify(this.loggedUser)
                );
                console.log('hay teacher');
                this.teacher = res as Teacher;
                this._teacherService._loggedTeacherObservable.next(
                  this.teacher
                );
                this._router.navigate([
                  `/teacher/${this.teacher.displayName}/feed`,
                ]);
              });
          }
        },
        error: (error) => {
          this._WrongCredentialsObservable.next(true);
        },
      });
  }

  logout() {
    sessionStorage.removeItem('currentUser');
    this._isLoggedObservable.next(false);
    this._router.navigate(['/login']);
  }

  signIn() {}
}
