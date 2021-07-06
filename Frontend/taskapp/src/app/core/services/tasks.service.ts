import { EditTask } from './../models/EditTask';
import { AppConstants } from './../constants/app-constants.service';
import { Subject } from 'rxjs/internal/Subject';
import { CreateTask } from '../models/CreateTask';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Output } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TasksService {

  @Output() public onTaskCreated: Subject<void> = new Subject<void>();

  constructor(
    private http: HttpClient,
    private appConstants: AppConstants,
  ) { }

  getUserAssignedTasks(id: number): Observable<any> {
    return this.http.get(this.appConstants.apiUserAssignedTasksRoute(id));
  }

  getUserCreatedTasks(id: number): Observable<any> {
    return this.http.get(this.appConstants.apiUserCreatedTasksRoute(id));
  }

  createTask(task: CreateTask): Observable<any> {
    return this.http.post(this.appConstants.apiCreateTaskRoute, task);
  }

  editTask(id:number, task: EditTask): Observable<any> {
    return this.http.put(this.appConstants.apiEditTaskRoute(id), task);
  }

  getLatestTasks(): Observable<any> {
    return this.http.get(this.appConstants.apiLatestTasksRoute);
  }
}
