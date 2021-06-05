import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Photo } from '../models/photo';
import { PhotoToCreate } from '../models/photo-to-create';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {
  baseUrl = "https://localhost:44356/api/";

  constructor(private http: HttpClient) {}

  getPhotosDetails(): Observable<Photo[]> {
    return this.http.get<Photo[]>(this.baseUrl + "photos");
  }

  postPhotoDetails(photo: PhotoToCreate) {
    return this.http.post(this.baseUrl + "photos", photo);
  }
}
