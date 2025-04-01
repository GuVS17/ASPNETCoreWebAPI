import { Component, OnDestroy, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { AlunoService } from '../../services/aluno.service';
import { ProfessorService } from '../../services/professor.service';
import { Aluno } from '../../models/Aluno';
import { Professor } from '../../models/Professor';
import { Observable } from 'rxjs';
import { PaginatedResult, Pagination } from '../../models/Pagination';

@Component({
  selector: 'app-alunos',
  standalone: false,
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css'],
})
export class AlunosComponent implements OnInit, OnDestroy {
  public modalRef: BsModalRef;
  public alunoForm: FormGroup;
  public titulo = 'Alunos';
  public alunoSelecionado: Aluno | null = null;
  public textSimple!: string;
  public profsAlunos!: Professor[];

  private unsubscriber = new Subject<void>();

  public alunos: Aluno[];
  public aluno: Aluno;
  public msnDeleteAluno!: string;
  public modeSave: 'post' | 'patch' = 'post';
  pagination: Pagination;

  constructor(
    private alunoService: AlunoService,
    private route: ActivatedRoute,
    private professorService: ProfessorService,
    private fb: FormBuilder,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {
    this.criarForm();
  }

  ngOnInit() {
    this.pagination = { currentPage: 1, itemsPerPage: 5,} as Pagination; // Inicializa a paginação com valores padrão
    this.carregarAlunos();
  }

  professoresAlunos(template: TemplateRef<any>, id: number) {
    this.spinner.show();
    this.professorService
      .getByAlunoId(id)
      .pipe(takeUntil(this.unsubscriber)) // pipe aplica operadores da biblioteca RxJS para modificar o fluxo de dados || O takeUntil mantém o código ativo até que this.unsubscriber emita um valor, momento que será parado
      .subscribe({
        next: (professores: Professor[]) => {
          this.profsAlunos = professores;
          this.modalRef = this.modalService.show(template);
        },
        error: (error: any) => {
          this.toastr.error(`erro: ${error}`);
          console.error(error);
        },
        complete: () => {
          this.spinner.hide();
        },
      });
  }

  criarForm() {
    this.alunoForm = this.fb.group({
      id: [0],
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      telefone: ['', Validators.required],
      ativo: [], //Foi colocado aqui pro código validar o campo, porque estava desativando quando clicava em enviar
    });
  }

  trocarEstado(aluno: Aluno) {
    this.alunoService
      .trocarEstado(aluno.id, !aluno.ativo) // O aluno.ativo é o valor atual do aluno, e o !aluno.ativo inverte o valor
      .pipe(takeUntil(this.unsubscriber))
      .subscribe({
        next: () => {
          this.carregarAlunos();
          this.toastr.success('Aluno salvo com sucesso!');
        },
        error: (error: any) => {
          this.toastr.error(`Erro: Aluno não pode ser salvo!`);
          console.error(error);
        },
        complete: () => this.spinner.hide(),
      });
  }

  //Original
  saveAluno() {
    if (this.alunoForm.valid) {
      this.spinner.show();

      if (this.modeSave === 'post') {
        this.aluno = { ...this.alunoForm.value };
      } else {
        if (this.alunoSelecionado)
          // Verificação se o alunoSelecionado é null
          this.aluno = {
            id: this.alunoSelecionado.id,
            ...this.alunoForm.value,
          };
      }
      this.alunoService[this.modeSave](this.aluno)
        .pipe(takeUntil(this.unsubscriber))
        .subscribe({
          next: () => {
            this.carregarAlunos();
            this.toastr.success('Aluno salvo com sucesso!');
          },
          error: (error: any) => {
            this.toastr.error(`Erro: Aluno não pode ser salvo!`);
            console.error(error);
          },
          complete: () => this.spinner.hide(),
        });
    }
  }

  carregarAlunos() {
    const alunoId = +(this.route.snapshot.paramMap.get('id') ?? '0'); // O original é sem as '??' e o 0 || Usando '??' para garantir um valor por padrão se for null

    this.spinner.show();
    this.alunoService
      .getAll(this.pagination.currentPage, this.pagination.itemsPerPage) // O getAll está pegando os alunos do serviço
      .pipe(takeUntil(this.unsubscriber))
      .subscribe({
        next: (alunos: PaginatedResult<Aluno[]>) => {
          this.alunos = alunos.result; //"alunos está sendo carregado pelo getAll, que está em alunos.services"
          this.pagination = alunos.pagination; // A paginação está sendo carregada pelo getAll, que está em alunos.services


          if (alunoId > 0) {
              this.alunoSelect(alunoId);
          }

          this.toastr.success('Alunos foram carregados com Sucesso!');
        },
        error: (error: any) => {
          this.toastr.error('Alunos não carregados!');
          console.error(error);
          this.spinner.hide();
        },
        complete: () => this.spinner.hide(),
      });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage=event.page;
    this.carregarAlunos();
  }

  alunoSelect(alunoId: number) {
    this.modeSave = 'patch';
    this.alunoService.getById(alunoId).subscribe({
      next: (alunoReturn) => {
        this.alunoSelecionado = alunoReturn;
        this.toastr.success('Alunos carregados!');
        this.alunoForm.patchValue(this.alunoSelecionado);
      },
      error: (error) => {
        this.toastr.error('Alunos não carregados!');
        console.error(error);
        this.spinner.hide();
      },
      complete: () => this.spinner.hide(),
    });
  }

  voltar() {
    if (this.alunoSelecionado) {
      this.alunoSelecionado = null;
    }
  }

  openModal(template: TemplateRef<any>, alunoId: number) {
    this.professoresAlunos(template, alunoId);
  }

  closeModal() {
    this.modalRef.hide();
  }

  ngOnDestroy(): void {
    this.unsubscriber.next();
    this.unsubscriber.complete();
  }
}
