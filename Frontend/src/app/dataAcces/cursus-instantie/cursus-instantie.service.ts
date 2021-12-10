import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'
import { CursusInstantie } from 'src/app/models/cursusInstantie';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CursusInsantieService {

  constructor(private httpClient: HttpClient) { }

  getAll(jaartal?: number, weekNr?: number): Observable<CursusInstantie[]> {

    //enkel jaartal of weekNr invoeren is buiten de scope. Ééntje niet ingevuld? => huidigeweek
    if(jaartal == null && weekNr == null ){
      return this.httpClient.get<CursusInstantie[]>(environment.apiUrl + 'cursusinstantie/');
    } else {
      return this.httpClient.get<CursusInstantie[]>(environment.apiUrl + 'cursusinstantie?jaar='+jaartal+'&weekNr='+weekNr);
    }
  }
}
