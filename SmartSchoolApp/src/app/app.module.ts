import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule} from '@angular/forms'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToastrModule } from 'ngx-toastr';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NgxSpinnerModule} from 'ngx-spinner';
import { NavComponent } from './components/shared/nav/nav.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TituloComponent } from './components/shared/titulo/titulo.component';
import { AlunosComponent } from './components/alunos/alunos.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ProfessoresComponent } from './components/professores/professores.component';
import { provideHttpClient } from '@angular/common/http';
import { AlunosProfessoresComponent} from './components/alunos/alunos-professores/alunos-professores.component';
import { ProfessoresAlunosComponent } from './components/professores/professores-alunos/professores-alunos.component';
import { ProfessorDetalheComponent } from './components/professores/professor-detalhe/professor-detalhe.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    TituloComponent,
    AlunosComponent,
    PerfilComponent,
    DashboardComponent,
    ProfessoresComponent,
    AlunosProfessoresComponent,
    ProfessoresAlunosComponent,
    ProfessorDetalheComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    PaginationModule.forRoot(),
    ModalModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    NgxSpinnerModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3500,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,
      closeButton: true
    })
  ],
  providers: [
    provideHttpClient()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
