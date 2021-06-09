import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Photo } from '../models/photo';
import { PhotoToCreate } from '../models/photo-to-create';
import { PhotoToUpdate } from '../models/photo-to-update';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {
  //baseUrl = "https://localhost:44356/api/";
  headers: HttpHeaders;

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  getPhotosDetails(): Observable<Photo[]> {
    return this.http.get<Photo[]>(this.envUrl.urlAddress + "/api/photos");
  }

  getPhotosDetailsById(id: number) {
    return this.http.get<Photo>(this.envUrl.urlAddress + "/api/photos/" + id);
  }

  postPhotoDetails(photo: PhotoToCreate) {
    return this.http.post(this.envUrl.urlAddress + "/api/photos", photo);
  }

  putPhotoDetails(photo: PhotoToUpdate) {
    return this.http.put(this.envUrl.urlAddress + "/api/photos", photo);
  }

  deletePhoto(id: number) {
    return this.http.delete(this.envUrl.urlAddress + "/api/photos/" + id, {headers: this.headers });
  }

  getUserPhotos(): Observable<Photo[]> {
    return this.http.get<Photo[]>(this.envUrl.urlAddress + "/api/photos/" + "myphotos");
  }
}
