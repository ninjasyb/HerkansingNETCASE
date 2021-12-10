import { Component, OnInit, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DateTime } from 'luxon';
import { Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-jaar-en-week-editor',
  templateUrl: './jaar-en-week-editor.component.html',
  styleUrls: ['./jaar-en-week-editor.component.css']
})
export class JaarEnWeekEditorComponent {
  jaarEnWeekForm = new FormGroup({
    week: new FormControl(),
    jaar: new FormControl(),
  });
  @Input() jaarEnWeek : number[];
  @Output() itemEmitter = new EventEmitter<number[]>();

  ngOnInit(){
    this.jaarEnWeekForm.setValue({
      jaar: this.jaarEnWeek[0],
      week: this.jaarEnWeek[1]
    })
  }

  getLastWeek(){
    let huidigeWeek = +this.jaarEnWeekForm.get('week').value;
    let eersteDagVorigeWeek : DateTime = DateTime.fromJSDate((this.getDateOfISOWeek(huidigeWeek -1, +this.jaarEnWeekForm.get('jaar').value)))

    if(huidigeWeek > eersteDagVorigeWeek.weekNumber){
      this.jaarEnWeekForm.get('week').setValue(huidigeWeek -1);
    } else{
      this.jaarEnWeekForm.get('week').setValue(eersteDagVorigeWeek.weekNumber);
      this.jaarEnWeekForm.get('jaar').setValue(+this.jaarEnWeekForm.get('jaar').value -1);
    }
  }

  getNextWeek(){
    let huidigeWeek = +this.jaarEnWeekForm.get('week').value;
    let eersteDagVolgendeWeek : DateTime = DateTime.fromJSDate((this.getDateOfISOWeek(huidigeWeek +1, +this.jaarEnWeekForm.get('jaar').value)))

    if(huidigeWeek < eersteDagVolgendeWeek.weekNumber){
      this.jaarEnWeekForm.get('week').setValue(huidigeWeek +1);
    } else{
      this.jaarEnWeekForm.get('week').setValue(eersteDagVolgendeWeek.weekNumber);
      this.jaarEnWeekForm.get('jaar').setValue(+this.jaarEnWeekForm.get('jaar').value +1);
    }
  }  
  onSubmit(){
    let pair = [
      +this.jaarEnWeekForm.get('jaar').value,
      +this.jaarEnWeekForm.get('week').value]
    this.itemEmitter.emit(pair);
    }
    
    getDateOfISOWeek(w : number, y: number) {
      var simple = new Date(Date.UTC(y, 0, 1 + (w - 1) * 7));
      var dow = simple.getDay();
      var ISOweekStart = simple;
      if (dow <= 4)
          ISOweekStart.setDate(simple.getDate() - simple.getDay() + 1);
      else
          ISOweekStart.setDate(simple.getDate() + 8 - simple.getDay());
      return ISOweekStart;
  }
}