import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { uploadResultaat } from 'src/app/models/uploadResultaat';
import { environment } from '../../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class UploadService {

  constructor(private httpClient: HttpClient) { }

  upload(formData: FormData): Observable<uploadResultaat> {
    return this.httpClient.post<uploadResultaat>(environment.apiUrl + 'upload', formData);
  }
}
