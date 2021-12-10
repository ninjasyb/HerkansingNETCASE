import { Component} from '@angular/core';
import { uploadResultaat } from 'src/app/models/uploadResultaat';
import { UploadService } from 'src/app/dataAcces/upload/upload.service';

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.css']
})
export class UploadFileComponent {

  file: File;
  error = false;
  uploadResult: uploadResultaat =  {
    nieuwCursussen: 0,
    nieuwInstanties: 0,
    duplicaten: 0,
    fout: false,
    bericht: ''
  };

  constructor (private uploadService: UploadService) { }

  handleFileInput(event: Event){
    const target = event.target as HTMLInputElement;
    this.file = (target.files as FileList)[0];
    this.submit();
  }

  submit(){
    const formData = new FormData();
    formData.append('file', this.file);

    this.uploadService.upload(formData).subscribe((result)=>{
      if(result){
        this.uploadResult = result;
        this.error = result.fout;
      }
    })
  }
}