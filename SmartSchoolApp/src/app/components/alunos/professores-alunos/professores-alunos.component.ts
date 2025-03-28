import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Professor } from '../../../models/Professor';
import { Router } from '@angular/router';
import { Disciplina } from '../../../models/Disciplina';
import { Util } from '../../../util/util';

@Component({
  selector: 'app-professores-alunos',
  templateUrl: './professores-alunos.component.html',
  styleUrls: ['./professores-alunos.component.css'],
  standalone: false
})
export class ProfessoresAlunosComponent implements OnInit {

  @Input() public professores: Professor[];
  @Output() closeModal = new EventEmitter();            //emite um evento chamando a função pai, no caso alunos.components

  constructor(private router: Router) { }

  ngOnInit() {
  }

  disciplinaConcat(disciplinas: Disciplina[]): string {
    return Util.nomeConcat(disciplinas);    //pegar a Disciplina
  }

  professorSelect(prof: Professor): void {
    this.closeModal.emit(null);
    this.router.navigate(['/professor', prof.id]);
  }

}
