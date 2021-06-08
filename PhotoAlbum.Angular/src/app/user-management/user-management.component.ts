import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserDTO } from '../models/user/user-dto';
import { UserToRegisterDTO } from '../models/user/user-to-register-dto';
import { PasswordConfirmationValidatorService } from '../services/password-confirmation-validator.service';
import { UserManagementService } from '../services/user-management.service';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css']
})
export class UserManagementComponent implements OnInit {
  public registerForm: FormGroup;
  public errorMessage: string = '';
  public showError: boolean;
  public isAddClicked: boolean;
  public users: UserDTO[];
  
  constructor(private userManagementService: UserManagementService, private _router: Router, 
    private _passConfValidator: PasswordConfirmationValidatorService) { }

  ngOnInit(): void {
    this.isAddClicked = false;
    this.getUsers();
  }

  getUsers() {
    this.userManagementService.getUsers().subscribe(result => this.users = result);
  }

  public makeForm() {
    this.isAddClicked = true;
    this.registerForm = new FormGroup({
    userName: new FormControl(''),
    password: new FormControl('', [Validators.required]),
    confirm: new FormControl('')
    });
    this.registerForm.get('confirm').setValidators([Validators.required,
    this._passConfValidator.validateConfirmPassword(this.registerForm.get('password'))]);
  }

  public validateControl(controlName: string) {
    return this.registerForm.controls[controlName].invalid && this.registerForm.controls[controlName].touched;
  }

  public hasError(controlName: string, errorName: string) {
    return this.registerForm.controls[controlName].hasError(errorName);
  }
  
  public createUser(registerFormValue: any) {
    this.showError = false;
    const formValues = { ...registerFormValue };

    const user: UserToRegisterDTO = {
      userName: formValues.userName,
      password: formValues.password,
      passwordConfirm: formValues.confirm
    };
    
    this.userManagementService.postUser("api/users/createuser", user)
    .subscribe(_ => {
      this.isAddClicked = false;
      this._router.navigate(["/usermanagement"]);
    },
    error => {
      this.errorMessage = error;
      this.showError = true;
    })
  }

  deleteUser(index: number) {
    let userId=this.users[index].id;
    this.userManagementService.deleteUser(userId).subscribe(()=> this.getUsers());
  }
}
