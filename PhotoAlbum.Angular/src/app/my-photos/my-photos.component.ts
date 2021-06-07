import { Component, OnInit } from '@angular/core';
import { Photo } from '../models/photo';
import { PhotoService } from '../services/photo.service';

@Component({
  selector: 'app-my-photos',
  templateUrl: './my-photos.component.html',
  styleUrls: ['./my-photos.component.css']
})
export class MyPhotosComponent implements OnInit {
  public photos: Photo[];

  constructor(private photoService: PhotoService) { }

  ngOnInit(): void {
    this.photoService.getUserPhotos().subscribe(result => this.photos = result);
  }

}
