import { Component, OnInit, TemplateRef } from '@angular/core';
import { Professor } from '../../../models/Professor';
import { Subject, takeUntil } from 'rxjs';
import { Aluno } from '../../../models/Aluno';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AlunoService } from '../../../services/aluno.service';
import { ProfessorService } from '../../../services/professor.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-professor-detalhe',
  templateUrl: './professor-detalhe.component.html',
  styleUrls: ['./professor-detalhe.component.css'],
  standalone: false,
})
export class ProfessorDetalheComponent implements OnInit {
  public modalRef: BsModalRef;
  public professorSelecionado: Professor;
  public titulo = '';
  public alunosProfs: Aluno[];
  private unsubscriber = new Subject<void>();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private professorService: ProfessorService,
    private alunoService: AlunoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {}

  openModal(template: TemplateRef<any>, alunoId: number) {
    this.alunosProfessores(template, alunoId);
  }

  closeModal() {
    this.modalRef.hide();
  }

  alunosProfessores(template: TemplateRef<any>, id: number) {
    this.spinner.show();
    this.alunoService
      .getByDisciplinaId(id)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe({
        next: (alunos: Aluno[]) => {
          this.alunosProfs = alunos;
          this.modalRef = this.modalService.show(template);
        },
        error: (error: any) => {
          this.toastr.error(`erro: ${error}`);
          console.log(error);
        },
        complete: () => this.spinner.hide()
      });
  }

  ngOnInit() {
    this.spinner.show();
    this.carregarProfessor();
  }

  carregarProfessor() {
    const profId = +(this.route.snapshot.paramMap.get('id') ?? '00');
    this.professorService
      .getById(profId)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe({
        next: (professor: Professor) => {
          this.professorSelecionado = professor;
          this.titulo = 'Professor: ' + this.professorSelecionado.id;
          this.toastr.success('Professor carregado com Sucesso!');
        },
        error: (error: any) => {
          this.toastr.error('Professor não carregados!');
          console.log(error);
        },
        complete: () => this.spinner.hide()
      });
  }

  voltar() {
    this.router.navigate(['/professores']);
  }

  ngOnDestroy(): void {
    this.unsubscriber.next();
    this.unsubscriber.complete();
  }
}
