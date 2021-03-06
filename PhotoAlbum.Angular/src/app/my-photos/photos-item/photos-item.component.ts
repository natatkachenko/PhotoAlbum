import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Photo } from 'src/app/models/photo';

@Component({
  selector: 'app-photos-item',
  templateUrl: './photos-item.component.html',
  styleUrls: ['./photos-item.component.css']
})
export class PhotosItemComponent implements OnInit {
  baseUrl = "https://localhost:44356/";
  @Input() item: Photo;
  @Output() update = new EventEmitter();
  @Output() delete = new EventEmitter();
  
  constructor() {}

  ngOnInit(): void {
  }

  createImagePath(path: string) {
    return `${this.baseUrl + path}`;
  }

  updateItem() {
    this.update.emit();
  }

  deleteItem() {
    this.delete.emit();
  }
}
