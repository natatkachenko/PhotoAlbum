import { Component, OnInit } from '@angular/core';
import { Photo } from '../models/photo';
import { PhotoToUpdate } from '../models/photo-to-update';
import { AuthenticationService } from '../services/authentication.service';
import { EnvironmentUrlService } from '../services/environment-url.service';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.css']
})
export class PhotosComponent implements OnInit {
  public photos: Photo[];
  public photoToUpdate: PhotoToUpdate;
  public isUserAuthenticated: boolean;

  constructor(private photoService: PhotoService, private envUrl: EnvironmentUrlService, private _authService: AuthenticationService) {}

  ngOnInit(): void {
    this.getPhotosDetails();
    this._authService.authChanged
    .subscribe(res => {
      this.isUserAuthenticated = res;
    })
  }

  getPhotosDetails() {
    this.photoService.getPhotosDetails().subscribe(result => this.photos = result);
  }

  createImagePath(path: string) {
    return `${this.envUrl.urlAddress + "/" + path}`;
  }

  increasePhotoRate(index: number) {
    this.photoToUpdate = {
      id: this.photos[index].id,
      title: this.photos[index].title,
      imagePath: this.photos[index].imagePath,
      userName: this.photos[index].userName,
      rate: ++this.photos[index].rate
    }

    this.photoService.putPhotoDetails(this.photoToUpdate).subscribe(() =>
    this.getPhotosDetails());
  }
}
