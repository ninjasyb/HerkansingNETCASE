import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CursusInstantieListComponent } from './components/cursus-instantie-list/cursus-instantie-list.component';
import { UploadFileComponent } from './components/upload-file/upload-file.component';
import { DateTime } from 'luxon';

const routes: Routes = [
  //{ path: '', component: CursusInstantieListComponent },
  { path: ':jaar/:week', component: CursusInstantieListComponent },
  { path: 'upload', component: UploadFileComponent },
  { path: '',   redirectTo: DateTime.now().year + '/' + DateTime.now().weekNumber, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
