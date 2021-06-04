import { Component, OnInit } from '@angular/core';
import { Photo } from '../models/photo';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.css']
})
export class PhotosComponent implements OnInit {
  public photos: Photo[];
  public title: string;
  public photo: Photo;
  public isCreate: boolean;

  constructor(private photoService: PhotoService) { }

  ngOnInit(): void {
    this.getPhotosDetails();
    this.isCreate = false;
  }

  getPhotosDetails() {
    this.photoService.getPhotosDetails().subscribe(result => this.photos = result);
  }

  addPhotoDetails() {
    this.photoService.postPhotoDetails(this.photos).subscribe(() => this.getPhotosDetails());
  }

  goToCreate() {
    this.isCreate = true;
    this.title = "";
  }
}
