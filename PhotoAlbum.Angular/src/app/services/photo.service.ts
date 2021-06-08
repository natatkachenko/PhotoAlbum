import { HttpClient, HttpHeaders } from '@angular/common/http';
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
  headers: HttpHeaders;

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  getPhotosDetails(): Observable<Photo[]> {
    return this.http.get<Photo[]>(this.baseUrl + "photos");
  }

  getPhotosDetailsById(id: number) {
    return this.http.get<Photo>(this.baseUrl + "photos/" + id);
  }

  postPhotoDetails(photo: PhotoToCreate) {
    return this.http.post(this.baseUrl + "photos", photo);
  }

  putPhotoDetails(photo: PhotoToUpdate) {
    return this.http.put(this.baseUrl + "photos", photo);
  }

  deletePhoto(id: number) {
    return this.http.delete(this.baseUrl + "photos/" + id, {headers: this.headers });
  }

  getUserPhotos(): Observable<Photo[]> {
    return this.http.get<Photo[]>(this.baseUrl + "photos/" + "myphotos");
  }
}
