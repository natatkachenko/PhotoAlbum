import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { PhotosComponent } from './photos/photos.component';
import { PhotosItemComponent } from './photos/photos-item/photos-item.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { UploadComponent } from './upload/upload.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterUserComponent } from './register-user/register-user.component';
import { MenuComponent } from './menu/menu.component';
import { RouterModule } from '@angular/router';
import { ErrorHandlerService } from './services/error-handler.service';

@NgModule({
  declarations: [
    AppComponent,
    PhotosComponent,
    PhotosItemComponent,
    UploadComponent,
    RegisterUserComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "api", component: PhotosComponent, pathMatch: 'full'},
      {path: "register", component: RegisterUserComponent},
      {path: "**", redirectTo: 'api'}
    ])
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
