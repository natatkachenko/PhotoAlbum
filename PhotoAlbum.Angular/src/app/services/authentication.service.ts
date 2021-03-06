import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subject } from 'rxjs';
import { UserToLoginDTO } from '../models/user/user-to-login-dto';
import { UserToRegisterDTO } from '../models/user/user-to-register-dto';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private _authChangeSub = new Subject<boolean>()
  public authChanged = this._authChangeSub.asObservable();

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService, private _jwtHelper: JwtHelperService) { }

  public registerUser(route: string, body: UserToRegisterDTO) {
    return this._http.post<UserToRegisterDTO> (this.createCompleteRoute(route, this._envUrl.urlAddress), body);
  }

  public loginUser(route: string, body: UserToLoginDTO) {
    return this._http.post(this.createCompleteRoute(route, this._envUrl.urlAddress), body);
  }

  public sendAuthStateChangeNotification(isAuthenticated: boolean) {
    this._authChangeSub.next(isAuthenticated);
  }

  public logOut() {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }

  public isUserAuthenticated() : boolean {
    const token = localStorage.getItem("token");
 
    return token && !this._jwtHelper.isTokenExpired(token);
  }

  private createCompleteRoute(route: string, envAddress: string) {
    return `${envAddress}/${route}`;
  }
}
