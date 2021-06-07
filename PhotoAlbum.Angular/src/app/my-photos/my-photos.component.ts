import { Component, OnInit } from '@angular/core';
import { Photo } from '../models/photo';
import { PhotoToCreate } from '../models/photo-to-create';
import { PhotoToUpdate } from '../models/photo-to-update';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-my-photos',
  templateUrl: './my-photos.component.html',
  styleUrls: ['./my-photos.component.css']
})
export class MyPhotosComponent implements OnInit {
  public photos: Photo[];
  public title: string;
  public photoToCreate: PhotoToCreate;
  public photoToUpdate: PhotoToUpdate;
  public isCreate: boolean;
  public isUpdate: boolean;
  
  public response: {dbPath: ''};

  constructor(private photoService: PhotoService) { }

  ngOnInit(): void {
    this.getUserPhotos();
    this.isCreate = false;
    this.isUpdate = false;
  }

  getUserPhotos() {
    this.photoService.getUserPhotos().subscribe(result => this.photos = result);
  }

  addPhotoDetails() {
    this.photoToCreate = {
      title: this.title,
      imagePath: this.response.dbPath
    }
    this.photoService.postPhotoDetails(this.photoToCreate).subscribe(() => {
      this.getUserPhotos();
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
      this.getUserPhotos();
      this.isUpdate = false;
    })
  }

  cancelUpdate() {
    this.isUpdate = false;
  }

  deletePhoto(index: number) {
    this.photoService.deletePhoto(index).subscribe(()=> this.getUserPhotos());
  }
}
