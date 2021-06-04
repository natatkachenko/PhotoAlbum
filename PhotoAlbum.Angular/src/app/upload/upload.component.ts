import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
  public progress: number;
  public message: string;
  baseUrl = "https://localhost:44356/api/";
  @Output() public uploadFinished = new EventEmitter();

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  public uploadFile = (files: string | any[]) => {
    if(files.length == 0) {
      return;
    }

    var fileToUpload = <File>files[0];
    var formData = new FormData();
    formData.append("file", fileToUpload, fileToUpload.name);

    this.http.post(this.baseUrl + "upload", formData, {reportProgress: true, observe: "events"})
      .subscribe(event => {
        if(event.type == HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if(event.type == HttpEventType.Response) {
          this.message = "Image has been uploaded!";
          this.uploadFinished.emit(event.body);
        }
      })
  }
}
