import { NgClass } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { Router } from '@angular/router';
import { Teacher } from 'src/app/Models/teacher';
import { User } from 'src/app/Models/user';
import { TeacherService } from 'src/app/services/teacher/teacher.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css'],
  imports: [FormsModule, ReactiveFormsModule,NgClass],
  standalone: true,
})
export class LoginPageComponent implements OnInit {
  isPassword: boolean = true;
  passwordInputType!: string;
  loginButtonToggle: boolean = true;
  userEmail!: string;
  userPassword!: string;
  loginForm!: FormGroup;

  constructor(
    private _authService: UserService,
    private _teacherService: TeacherService,
    private _router: Router
  ) {}

  loggedUser!: User;
  teacher!: Teacher;
  hasUserEnteredWrongCredentials!: boolean ;
  ngOnInit(): void {
    this.hasUserEnteredWrongCredentials = false
    this._authService._EnteredWrongCredentials.subscribe((res) => {
      this.hasUserEnteredWrongCredentials = res;})
    if (this._authService.CheckIsLogged()) {
      
      this._authService.loggedUserInfo.subscribe((res) => {
        this.loggedUser = res;

        if (this.loggedUser.roleId == 1) {
          this._teacherService
            .getTeacherInfo(this.loggedUser.profileId)
            .subscribe((res) => {
              console.log(res + 'from login');
              this.teacher = res as Teacher;
              this._router.navigate([`teacher/${this.teacher.displayName}/feed`]);
            });
        }
      });
    }
    

    //

    this.loginButtonToggle = false;
    this.isPassword = true;
    if (this.isPassword) {
      this.passwordInputType = 'password';
    } else {
      this.passwordInputType = 'text';
    }

    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
    });
  }

  passwordToggle() {
    this.isPassword = !this.isPassword;
    if (this.isPassword) {
      this.passwordInputType = 'password';
    } else {
      this.passwordInputType = 'text';
    }
  }

  login() {
    console.log('Login Clickeado, aun no se ha validado el formulario');

    this.loginButtonToggle = true;

    if (this.loginForm.valid) {
      console.log('Formulario valido');

      this.userEmail = this.loginForm.get('email')?.value;

      this.userPassword = this.loginForm.get('password')?.value;

      this._authService.login(this.userEmail, this.userPassword);

      this.loginButtonToggle = false;
    } else {
      this.loginButtonToggle = false;
    }
  }
}
