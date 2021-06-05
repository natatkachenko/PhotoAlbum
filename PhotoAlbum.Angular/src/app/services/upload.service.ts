import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UploadService {
  baseUrl = "https://localhost:44356/api/";

  constructor(private http: HttpClient) {}

  postFile(formData: FormData) {
    return this.http.post(this.baseUrl + "upload", formData, {reportProgress: true, observe: "events"});
  }
}