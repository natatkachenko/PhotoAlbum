import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UploadService {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
   }

  postFile(formData: FormData) {
    return this.http.post(this.baseUrl + "upload", formData, {reportProgress: true, observe: "events"});
  }
}