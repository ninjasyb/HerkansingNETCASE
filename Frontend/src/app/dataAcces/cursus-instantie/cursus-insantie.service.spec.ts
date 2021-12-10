import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from 'src/app/app-routing.module';

import { CursusInsantieService } from './cursus-instantie.service';

describe('CursusInsantieService', () => {
  let mockHttpClient: { get: jasmine.Spy };
  let service: CursusInsantieService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [    
        BrowserModule,
        HttpClientModule,
        AppRoutingModule,
        NgbModule,
        ReactiveFormsModule
    ]});
    mockHttpClient = jasmine.createSpyObj('HttpClient', ['get']);
    service = new CursusInsantieService(mockHttpClient as any);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
