import { HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { UploadService } from '../services/upload.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
  public progress: number;
  public message: string;
  
  @Output() public uploadFinished = new EventEmitter();

  constructor(private UploadService: UploadService) { }

  ngOnInit(): void {
  }
  
  public uploadFile(files: string | any[]) {
    if(files.length == 0) {
      return;
    }

    var fileToUpload = <File>files[0];
    var formData = new FormData();
    formData.append("file", fileToUpload, fileToUpload.name);

    this.UploadService.uploadFile(formData).subscribe(event => {
      if(event.type == HttpEventType.UploadProgress)
        this.progress = Math.round(100 * event.loaded / event.total);
      else if(event.type == HttpEventType.Response) {
        this.message = "Image has been uploaded!";
        this.uploadFinished.emit(event.body);
      }
    });
  }
}
