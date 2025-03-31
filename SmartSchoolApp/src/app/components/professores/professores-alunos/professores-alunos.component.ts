import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Aluno } from '../../../models/Aluno';
import { Router } from '@angular/router';

@Component({
  selector: 'app-professores-alunos',
  templateUrl: './professores-alunos.component.html',
  styleUrls: ['./professores-alunos.component.css'],
  standalone: false
})
export class ProfessoresAlunosComponent implements OnInit {

  @Input() public alunos: Aluno[];
  @Output() closeModal = new EventEmitter();

  constructor(private router: Router) { }

  ngOnInit() {
  }

  alunoSelect(id: number) {
    this.closeModal.emit(null);
    this.router.navigate(['/alunos', id]);
  }

}
