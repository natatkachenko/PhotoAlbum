import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginResponseDTO } from '../models/user/login-response-dto';
import { UserToLoginDTO } from '../models/user/user-to-login-dto';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.css']
})
export class LoginUserComponent implements OnInit {
  public loginForm: FormGroup;
  public errorMessage: string = '';
  public showError: boolean;
  private _returnUrl: string;
  private token: string;

  constructor(private _authService: AuthenticationService, private _router: Router, private _route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required])
    });

    this._returnUrl = this._route.snapshot.queryParams['returnUrl'] || '/';
  }

  public validateControl(controlName: string) {
    return this.loginForm.controls[controlName].invalid && this.loginForm.controls[controlName].touched;
  }

  public hasError(controlName: string, errorName: string) {
    return this.loginForm.controls[controlName].hasError(errorName);
  }

  public loginUser(loginFormValue) {
    this.showError = false;
    const login = {... loginFormValue };
    const userForAuth: UserToLoginDTO = {
      userName: login.username,
      password: login.password
    }

    this._authService.loginUser('api/accounts/login', userForAuth)
    .subscribe((res : LoginResponseDTO) => {
      localStorage.setItem("token", res.token);
      this._router.navigate([this._returnUrl]);
    },
    (error) => {
      this.errorMessage = error;
      this.showError = true;
    })
  }
}
