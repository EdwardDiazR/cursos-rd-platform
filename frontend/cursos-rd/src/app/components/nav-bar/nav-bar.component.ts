import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { Teacher } from 'src/app/Models/teacher';
import { User } from 'src/app/Models/user';
import { TeacherService } from 'src/app/services/teacher/teacher.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit,OnChanges {
  constructor(
    private _authService: UserService,
    private _teacherService: TeacherService
  ) {}

  UserInfo!: User;
  teacher!: Teacher;
  userIsLogged!: boolean;
  loggedUserInfo!: User;
  profileRoute!: string;

  showMobileSideMenu!:boolean;

  @Output() isShowingMobile = new EventEmitter<boolean>();

  ngOnInit(): void {
    this.showMobileSideMenu = false
    console.log('SE MONTO EL NAVBAR');

    this._authService.isLogged.subscribe((res) => {
      this.userIsLogged = res;
    });

    this._teacherService._loggedTeacher.subscribe(
      (res) => (this.teacher = res)
    );

    this._authService.loggedUserInfo.subscribe(res=>this.loggedUserInfo=res)

    // //If user is logged in
    // if (this.userIsLogged) {
    //   console.log('HAY UN USUARIO LOGUEADO');
    //   this._authService.loggedUserInfo.subscribe((res) => {
    //     console.log('INFO DEL USUARIO LOGUEADO => id:' + res.profileId);

    //     this.loggedUserInfo = res as User;

    //     if (this.loggedUserInfo.roleId == 1) {
    //       this._teacherService._loggedTeacher.subscribe((res) => {
    //         if (!res) {
    //           console.log('NO HAY INFORMACION DEL TEACHER, ...llamando API');
    //           this._teacherService
    //             .getTeacherInfo(this.loggedUserInfo.profileId)
    //             .subscribe({
    //               next: (res) => {
    //                 this._teacherService._loggedTeacher.subscribe(
    //                   (res) => (this.teacher = res)
    //                 );
    //                 this._teacherService._loggedTeacherObservable.next(
    //                   res as Teacher
    //                 );
    //               },
    //               complete: () => {
    //                 console.log('completed');
    //               },
    //             });
    //         } else {
    //           console.log('HAY TEACHER LOGUEADO => ' + res.displayName);
    //         }
    //       });
    //     }
    //   });
    // }
  }


  mobileSideMenuToggle(){
    this.showMobileSideMenu = !this.showMobileSideMenu
    this.isShowingMobile.emit(this.showMobileSideMenu)
  }

  linkPressed(){
    this.showMobileSideMenu = false
  }
  logout() {
    this._authService.logout();
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log("SE DETECTO CAMBIO")
  }
}
