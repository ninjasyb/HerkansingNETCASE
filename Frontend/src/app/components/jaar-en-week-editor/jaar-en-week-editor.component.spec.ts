import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from 'src/app/app-routing.module';

import { JaarEnWeekEditorComponent } from './jaar-en-week-editor.component';

describe('JaarEnWeekEditorComponent', () => {
  let component: JaarEnWeekEditorComponent;
  let fixture: ComponentFixture<JaarEnWeekEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [    
        BrowserModule,
        HttpClientModule,
        AppRoutingModule,
        NgbModule,
        ReactiveFormsModule
    ],
      declarations: [ JaarEnWeekEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(JaarEnWeekEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });


});
