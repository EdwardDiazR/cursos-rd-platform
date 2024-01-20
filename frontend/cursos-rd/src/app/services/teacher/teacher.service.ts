import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { Teacher } from 'src/app/Models/teacher';
import { User } from 'src/app/Models/user';
import { environment } from 'src/app/environment';

@Injectable({
  providedIn: 'root',
})
export class TeacherService {
  constructor(private _http: HttpClient) {}
  loggedTeacher!: Teacher;

  loggedUser: User = JSON.parse(sessionStorage.getItem('currentUser')!) as User;

  public _loggedTeacherObservable: BehaviorSubject<Teacher> =
    new BehaviorSubject<Teacher>(this.loggedTeacher);

  get _loggedTeacher() {
    return this._loggedTeacherObservable.asObservable();
  }

  getTeacherInfo(ProfileId: number) {
    return this._http.get(
      `${environment.apiUrl}/teacher/${ProfileId}/profile`,
      {
        params: {
          TeacherId: ProfileId,
        },
      }
    );
  }
}
