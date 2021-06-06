import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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

  private createCompleteRoute(route: string, envAddress: string) {
    return `${envAddress}/${route}`;
  }
}