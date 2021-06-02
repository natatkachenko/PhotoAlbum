import { Component, Input, OnInit } from '@angular/core';
import { Photo } from 'src/app/models/photo';

@Component({
  selector: 'app-photos-item',
  templateUrl: './photos-item.component.html',
  styleUrls: ['./photos-item.component.css']
})
export class PhotosItemComponent implements OnInit {
  @Input() item: Photo;
  
  constructor() { }

  ngOnInit(): void {
  }

}
