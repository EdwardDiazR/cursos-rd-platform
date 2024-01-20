import { Component, EventEmitter, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { UserService } from './services/user/user.service';
import { User } from './Models/user';
import { TeacherService } from './services/teacher/teacher.service';
import { Teacher } from './Models/teacher';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(
    private _authService: UserService,
    private _teacherService: TeacherService
  ) {}
  title = 'Cursos RD';
  isLogged!: boolean;

  loggedUserInfo!: User;
  isShowingMobileNav!: boolean;

  @Output() showingMenuEmitter = new EventEmitter<boolean>()

  isMobileNavBar(value: boolean) {
    this.isShowingMobileNav = value;
    console.log(this.isShowingMobileNav ? 'MOSTRANDO MOBILE SIDE MENU' : 'SE HA OCULTADO EL MOBILE SIDE MENU');
    this.showingMenuEmitter.emit(this.isShowingMobileNav)
  }

  ngOnInit(): void {
    this.isShowingMobileNav = false;
    this._authService.CheckIsLogged();
    this._authService.isLogged.subscribe((res) => (this.isLogged = res));

    //If user is logged in
    if (this.isLogged) {
      console.log('HAY UN USUARIO LOGUEADO');
      this._authService.loggedUserInfo.subscribe((res) => {
        console.log('INFO DEL USUARIO LOGUEADO => id:' + res.profileId);

        this.loggedUserInfo = res as User;

        if (this.loggedUserInfo.roleId == 1) {
          this._teacherService._loggedTeacher.subscribe((res) => {
            if (!res) {
              console.log('NO HAY INFORMACION DEL TEACHER, ...llamando API');
              this._teacherService
                .getTeacherInfo(this.loggedUserInfo.profileId)
                .subscribe({
                  next: (res) => {
                    this._teacherService._loggedTeacherObservable.next(
                      res as Teacher
                    );
                  },
                  complete: () => {
                    console.log('completed');
                  },
                });
            } else {
              console.log('HAY TEACHER LOGUEADO => ' + res.displayName);
            }
          });
        }
      });
    }
  }
}
