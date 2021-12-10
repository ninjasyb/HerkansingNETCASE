import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CursusInstantieListComponent } from './components/cursus-instantie-list/cursus-instantie-list.component';
import { UploadFileComponent } from './components/upload-file/upload-file.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { JaarEnWeekEditorComponent } from './components/jaar-en-week-editor/jaar-en-week-editor.component';

@NgModule({
  declarations: [
    AppComponent,
    CursusInstantieListComponent,
    UploadFileComponent,
    JaarEnWeekEditorComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
