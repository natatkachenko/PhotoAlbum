import { HttpClient } from '@angular/common/http';
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

  constructor(private photoService: PhotoService) { }

  ngOnInit(): void {
    this.getPhotosDetails();
  }

  getPhotosDetails() {
    this.photoService.getPhotos().subscribe(result => this.photos = result);
  }
  
  addPhotoDetails() {
    this.photoService.addPhotoDetails(this.photos).subscribe(() => this.getPhotosDetails());
  }
}
