import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UploadService {
  baseUrl = "https://localhost:44356/api/";

  constructor(private http: HttpClient) { }

  uploadFile(formData: FormData) {
    return this.http.post(this.baseUrl + "upload", formData, {reportProgress: true, observe: "events"});
  }
}