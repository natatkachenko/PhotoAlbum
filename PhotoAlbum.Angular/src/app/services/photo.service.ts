import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Photo } from '../models/photo';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
   }

  getPhotosDetails(): Observable<Photo[]> {
    return this.http.get<Photo[]>(this.baseUrl + "photos");
  }

  postPhotoDetails(photo: Photo) {
    return this.http.post<Photo>(this.baseUrl + "photos", photo);
  }
}
