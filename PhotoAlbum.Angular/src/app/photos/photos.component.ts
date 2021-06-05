import { Component, OnInit } from '@angular/core';
import { Photo } from '../models/photo';
import { PhotoToCreate } from '../models/photo-to-create';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.css']
})
export class PhotosComponent implements OnInit {
  public photos: Photo[];
  public title: string;
  public photo: PhotoToCreate;
  public isCreate: boolean;
  public response: {dbPath: ''};

  constructor(private photoService: PhotoService) { }

  ngOnInit(): void {
    this.getPhotosDetails();
    this.isCreate = false;
  }

  getPhotosDetails() {
    this.photoService.getPhotosDetails().subscribe(result => this.photos = result);
  }

  addPhotoDetails() {
    this.photo = {
      title: this.title,
      imagePath: this.response.dbPath
    }
    this.photoService.postPhotoDetails(this.photo).subscribe(() => this.getPhotosDetails());
  }

  goToCreate() {
    this.isCreate = true;
    this.title = "";
  }

  uploadFinished(event: any) {
    this.response = event;
  }
}
