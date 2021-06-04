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
  
  @Output() public onUploadFinished = new EventEmitter();

  constructor(private uploadService: UploadService) { }

  ngOnInit(): void {
  }
  
  public uploadFile(files: any) {
    if(files.length == 0) {
      return;
    }

    var fileToUpload = <File>files[0];
    var formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.uploadService.postFile(formData).subscribe(event => {
      if(event.type == HttpEventType.UploadProgress){
        this.progress = event.total ? Math.round(100 * event.loaded / event.total) : 0;
        if(this.progress == 0)
          console.log(`${event.total} was undefined.`);
      }
      else if(event.type == HttpEventType.Response) {
        this.message = "Image has been uploaded!";
        this.onUploadFinished.emit(event.body);
      }
    });
  }
}
