import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlunosComponent } from './components/alunos/alunos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { ProfessoresComponent } from './components/professores/professores.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'alunos', component: AlunosComponent },
  { path: 'professores', component: ProfessoresComponent },
  { path: 'perfil', component: PerfilComponent },
  { path: '', redirectTo: "dashboard", pathMatch: "full" }, //Quando não for selecionado nada, vai ir pro dashboard || É para seguir a rota certa, o campo só pode estar vazio
  { path: '**', redirectTo: "dashboard", pathMatch: "full" } // Se for digitado qualquer coisa diferente do esperado, ele também vai pro dashboard
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
