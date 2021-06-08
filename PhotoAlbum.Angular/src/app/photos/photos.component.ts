import { Component, OnInit } from '@angular/core';
import { Photo } from '../models/photo';
import { EnvironmentUrlService } from '../services/environment-url.service';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.css']
})
export class PhotosComponent implements OnInit {
  public photos: Photo[];

  constructor(private photoService: PhotoService, private envUrl: EnvironmentUrlService) {}

  ngOnInit(): void {
    this.getPhotosDetails();
  }

  getPhotosDetails() {
    this.photoService.getPhotosDetails().subscribe(result => this.photos = result);
  }

  createImagePath(path: string) {
    return `${this.envUrl.urlAddress + "/" + path}`;
  }
}
