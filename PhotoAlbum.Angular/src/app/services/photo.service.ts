import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Photo } from '../models/photo';
import { PhotoToCreate } from '../models/photo-to-create';
import { PhotoToUpdate } from '../models/photo-to-update';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {
  baseUrl = "https://localhost:44356/api/";

  constructor(private http: HttpClient) {}

  getPhotosDetails(): Observable<Photo[]> {
    return this.http.get<Photo[]>(this.baseUrl + "photos");
  }

  getPhotosDetailsById(id: number) {
    return this.http.get<Photo>(this.baseUrl + "photos" + "/" + ++id);
  }

  postPhotoDetails(photo: PhotoToCreate) {
    return this.http.post(this.baseUrl + "photos", photo);
  }

  putPhotoDetails(photo: PhotoToUpdate) {
    return this.http.put(this.baseUrl + "photos", photo);
  }
}
