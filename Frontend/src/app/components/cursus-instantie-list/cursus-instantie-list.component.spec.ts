import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from 'src/app/app-routing.module';

import { CursusInstantieListComponent } from './cursus-instantie-list.component';

describe('CursusInstantieListComponent', () => {
  let sut: CursusInstantieListComponent;
  let fixture: ComponentFixture<CursusInstantieListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [    
        BrowserModule,
        HttpClientModule,
        AppRoutingModule,
        NgbModule,
        ReactiveFormsModule
    ],
      declarations: [ CursusInstantieListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CursusInstantieListComponent);
    sut = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(sut).toBeTruthy();
  });

  it('should get cursusInstanties', () =>{
    sut.ngOnInit();
    //ToDo
  })
});
