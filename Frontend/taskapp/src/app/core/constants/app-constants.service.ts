import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AppConstants {
  // API Endpoints

  // Auth
  public apiAuthRoute: string = `${environment.AUTH_API_URL}api/auth`;

  // Photos
  public apiAddPhotoRoute: string = `${environment.PHOTOS_API_URL}api/photos`;

  // Tasks
  public apiUserAssignedTasksRoute(id: number): string {
    return `${environment.TASKS_API_URL}api/tasks/assigned/${id}`; 
  } 

  public apiUserCreatedTasksRoute(id: number): string {
    return `${environment.TASKS_API_URL}api/tasks/${id}`;
  }

  public apiEditTaskRoute(id: number): string {
    return `${environment.TASKS_API_URL}api/tasks/${id}`;
  }

  public apiCreateTaskRoute: string = `${environment.TASKS_API_URL}api/tasks`;
  public apiLatestTasksRoute: string = `${environment.TASKS_API_URL}api/tasks`;
  public apiDownloadTasksRoute: string = `${environment.TASKS_API_URL}api/tasks/download`;

  // Users
  public apiCreateUserRoute: string = `${environment.USERS_API_URL}api/users`;

  public apiUserByIdRoute(id: number): string {
    return `${environment.USERS_API_URL}api/users/${id}`;
  }
  
  public apiAllUsersRoute: string = `${environment.USERS_API_URL}api/users`;

  // Local Storage items
  public localStorageUser: string = `user`;
  public localStorageToken: string = `token`;

  // Form Data
  public formDataAppendPhotoFile: string = `PhotoFile`;
  public formDataAppendUserId: string = `UserId`;
}
