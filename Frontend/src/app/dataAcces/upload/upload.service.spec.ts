import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { uploadResultaat } from 'src/app/models/uploadResultaat';

import { UploadService } from './upload.service';

describe('UploadService', () => {
  let mockHttpClient: { post: jasmine.Spy };
  let service: UploadService;

  beforeEach(() => {
    mockHttpClient = jasmine.createSpyObj('HttpClient', ['post']);

    TestBed.configureTestingModule({});
    service = new UploadService(mockHttpClient as any);

  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

});
