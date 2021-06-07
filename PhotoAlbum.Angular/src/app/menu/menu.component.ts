import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  public isUserAuthenticated: boolean;

  constructor(private _authService: AuthenticationService) { }

  ngOnInit(): void {
    this._authService.authChanged
    .subscribe(res => {
      this.isUserAuthenticated = res;
    })
  }

}
