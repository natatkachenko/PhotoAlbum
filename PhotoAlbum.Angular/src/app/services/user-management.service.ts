import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserToRegisterDTO } from '../models/user/user-to-register-dto';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class UserManagementService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService,) { }

  postUser(route: string, body: UserToRegisterDTO) {
    return this.http.post<UserToRegisterDTO> (this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }

  private createCompleteRoute(route: string, envAddress: string) {
    return `${envAddress}/${route}`;
  }
}
