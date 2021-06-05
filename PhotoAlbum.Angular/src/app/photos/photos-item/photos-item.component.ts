import { Component, Inject, Input, OnInit } from '@angular/core';
import { Photo } from 'src/app/models/photo';

@Component({
  selector: 'app-photos-item',
  templateUrl: './photos-item.component.html',
  styleUrls: ['./photos-item.component.css']
})
export class PhotosItemComponent implements OnInit {
  baseUrl: string;
  @Input() item: Photo;
  
  constructor(@Inject('BASE_URL') baseUrl: string) { 
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
  }

  createImagePath(path: string) {
    return `${this.baseUrl + path}`;
  }
}
