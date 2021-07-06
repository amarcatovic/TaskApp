import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConstants } from '../constants/app-constants.service';

@Injectable({
  providedIn: 'root'
})
export class PhotosService {

  constructor(
    private http: HttpClient,
    private appConstants: AppConstants,
    ) { }

  public uploadPhotoForUser(userId: number, photoFile: File): Observable<any> {
    const formData: FormData = new FormData();
    formData.append(this.appConstants.formDataAppendPhotoFile, photoFile, photoFile.name);
    formData.append(this.appConstants.formDataAppendUserId, userId.toString());

    return this.http.post(this.appConstants.apiAddPhotoRoute, formData);
  }
}
