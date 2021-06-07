import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginResponseDTO } from '../models/user/login-response-dto';
import { UserToLoginDTO } from '../models/user/user-to-login-dto';
import { UserToRegisterDTO } from '../models/user/user-to-register-dto';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  public registerUser(route: string, body: UserToRegisterDTO) {
    return this._http.post<UserToRegisterDTO> (this.createCompleteRoute(route, this._envUrl.urlAddress), body);
  }

  public loginUser(route: string, body: UserToLoginDTO) {
    return this._http.post(this.createCompleteRoute(route, this._envUrl.urlAddress), body);
  }

  private createCompleteRoute(route: string, envAddress: string) {
    return `${envAddress}/${route}`;
  }
}
