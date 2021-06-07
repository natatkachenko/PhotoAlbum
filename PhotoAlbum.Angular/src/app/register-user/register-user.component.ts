import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserToRegisterDTO } from '../models/user/user-to-register-dto';
import { AuthenticationService } from '../services/authentication.service';
import { PasswordConfirmationValidatorService } from '../services/password-confirmation-validator.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  public registerForm: FormGroup;
  
  constructor(private _authService: AuthenticationService, private _passConfValidator: PasswordConfirmationValidatorService) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      userName: new FormControl(''),
      password: new FormControl('', [Validators.required]),
      confirm: new FormControl('')
    });
    this.registerForm.get('confirm').setValidators([Validators.required,
      this._passConfValidator.validateConfirmPassword(this.registerForm.get('password'))]);
  }

  public validateControl(controlName: string) {
    return this.registerForm.controls[controlName].invalid && this.registerForm.controls[controlName].touched
  }

  public hasError(controlName: string, errorName: string) {
    return this.registerForm.controls[controlName].hasError(errorName)
  }

  public registerUser(registerFormValue: any) {
    const formValues = { ...registerFormValue };

    const user: UserToRegisterDTO = {
      userName: formValues.userName,
      password: formValues.password,
      confirmPassword: formValues.confirm
    };
    
    this._authService.registerUser("api/accounts/registration", user)
    .subscribe(_ => {
      console.log("Successful registration");
    },
    error => {
      console.log(error.error.errors);
    })
  }

}
