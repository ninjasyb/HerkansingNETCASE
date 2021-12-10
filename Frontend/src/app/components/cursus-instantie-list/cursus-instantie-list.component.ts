import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CursusInstantie } from 'src/app/models/cursusInstantie';
import {CursusInsantieService} from '../../dataAcces/cursus-instantie/cursus-instantie.service'
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-cursus-instantie-list',
  templateUrl: './cursus-instantie-list.component.html',
  styleUrls: ['./cursus-instantie-list.component.css']
})
export class CursusInstantieListComponent implements OnInit {

  cursusInstanties: CursusInstantie[] = [];
  isLoading = true;
  jaarEnWeek: number[] = [];
  
  constructor(
    private cursusInsantieService: CursusInsantieService,
    private activatedRoute: ActivatedRoute,
    private router: Router
    ) {}

  
    ngOnInit(): void {
        this.activatedRoute.params.subscribe(params =>{
              this.jaarEnWeek[0] = params['jaar'];
              this.jaarEnWeek[1] = params['week'];
            })
        this.getCursusInstanties(this.jaarEnWeek[0], this.jaarEnWeek[1]);
    }


    getCursusInstanties(jaar: number, week: number) {
        this.cursusInsantieService.getAll(jaar, week).subscribe((result) =>{
          if(result){
            this.cursusInstanties =result;
            this.isLoading =false;
          }
        })
    }

    updateList(jaarenWeek?: number[]){
        this.router.navigate(['', jaarenWeek[0], jaarenWeek[1]]);
        this.getCursusInstanties(jaarenWeek[0], jaarenWeek[1])
    }
}
  
