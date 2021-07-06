import { AppConstants } from './../constants/app-constants.service';
import { Router } from '@angular/router';
import { Subject } from 'rxjs/internal/Subject';
import { Observable } from 'rxjs';
import { Login } from '../models/Login';
import { HttpClient } from '@angular/common/http';
import { Injectable, Output } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  @Output() public userLoggedIn: Subject<boolean> = new Subject<boolean>();

  constructor(
    private http: HttpClient,
    private router: Router,
    private appConstants: AppConstants,
  ) { }

  logUserIn(login: Login): Observable<any> {
    return this.http.post(this.appConstants.apiAuthRoute, login);
  }

  public userHasLoggedIn() {
    this.userLoggedIn.next(true);
  }

  public logOff() {
    localStorage.removeItem(this.appConstants.localStorageUser);
    localStorage.removeItem(this.appConstants.localStorageToken);
    this.userLoggedIn.next(false);
    this.router.navigate(['/']);
  }
}
