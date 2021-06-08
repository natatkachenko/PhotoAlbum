import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDTO } from '../models/user/user-dto';
import { UserToRegisterDTO } from '../models/user/user-to-register-dto';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class UserManagementService {
  headers: HttpHeaders;
  
  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { 
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  postUser(route: string, body: UserToRegisterDTO) {
    return this.http.post<UserToRegisterDTO> (this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }

  getUsers(): Observable<UserDTO[]> {
    return this.http.get<UserDTO[]>(this.envUrl.urlAddress + "/api/users");
  }

  deleteUser(id: string) {
    return this.http.delete(this.envUrl.urlAddress + "/api/users/" + id, {headers: this.headers });
  }

  private createCompleteRoute(route: string, envAddress: string) {
    return `${envAddress}/${route}`;
  }
}
