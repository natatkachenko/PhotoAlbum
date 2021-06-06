import { Component, OnInit } from '@angular/core';
import { Photo } from '../models/photo';
import { PhotoToCreate } from '../models/photo-to-create';
import { PhotoToUpdate } from '../models/photo-to-update';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.css']
})
export class PhotosComponent implements OnInit {
  public photos: Photo[];
  public title: string;
  public photoToCreate: PhotoToCreate;
  public photoToUpdate: PhotoToUpdate;
  public isCreate: boolean;
  public isUpdate: boolean;
  
  public response: {dbPath: ''};

  constructor(private photoService: PhotoService) { }

  ngOnInit(): void {
    this.getPhotosDetails();
    this.isCreate = false;
    this.isUpdate = false;
  }

  getPhotosDetails() {
    this.photoService.getPhotosDetails().subscribe(result => this.photos = result);
  }

  addPhotoDetails() {
    this.photoToCreate = {
      title: this.title,
      imagePath: this.response.dbPath
    }
    this.photoService.postPhotoDetails(this.photoToCreate).subscribe(() => {
      this.getPhotosDetails();
      this.isCreate = false;
    });
  }

  goToCreate() {
    this.isCreate = true;
    this.title = "";
  }

  uploadFinished(event: any) {
    this.response = event;
  }

  cancelAdd() {
    this.isCreate = false;
  }

  getPhotoDetailsByIndex(index: number) {
    this.photoService.getPhotosDetailsById(index).subscribe(result=> {
      this.photoToUpdate = result;
      this.isUpdate = true;
    });
  }
  
  updatePhotoDetails() {
    this.photoToUpdate = {
      id: this.photoToUpdate.id,
      title: this.title,
      imagePath: this.photoToUpdate.imagePath
    }
    this.photoService.putPhotoDetails(this.photoToUpdate).subscribe(() =>{
      this.getPhotosDetails();
      this.isUpdate = false;
    })
  }

  cancelUpdate() {
    this.isUpdate = false;
  }
}
