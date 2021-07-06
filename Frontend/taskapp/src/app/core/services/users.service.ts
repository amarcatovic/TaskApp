import { AppConstants } from './../constants/app-constants.service';
import { CraeteUser } from '../models/CreateUser';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(
    private http: HttpClient,
    private appConstants: AppConstants,  
  ) { }

  createUser(user: CraeteUser): Observable<any> {
    return this.http.post(this.appConstants.apiCreateUserRoute, user);
  }

  getUserById(id: number): Observable<any> {
    return this.http.get(this.appConstants.apiUserByIdRoute(id));
  }

  getAllUsers(): Observable<any> {
    return this.http.get(this.appConstants.apiAllUsersRoute);
  }
}
