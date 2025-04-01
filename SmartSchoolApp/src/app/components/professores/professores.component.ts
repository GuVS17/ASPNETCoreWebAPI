import { ChangeDetectorRef, Component, DoCheck, Input, OnInit, SimpleChanges} from '@angular/core';
import { Util } from '../../util/util';
import { Disciplina } from '../../models/Disciplina';
import { Professor } from '../../models/Professor';
import { Subject, takeUntil } from 'rxjs';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ProfessorService } from '../../services/professor.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.css'],
  standalone: false,
})
export class ProfessoresComponent implements OnInit {
  public titulo = 'Professores';
  public professorSelecionado: Professor;
  private unsubscriber = new Subject<void>();

  public professores: Professor[];

  constructor(
    private router: Router,
    private professorService: ProfessorService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private cdr: ChangeDetectorRef
  ) {}


  carregarProfessores() {
    this.spinner.show();
    this.professorService
      .getAll()
      .pipe(takeUntil(this.unsubscriber))
      .subscribe({
        next: (professores: Professor[]) => {
          this.professores = professores;
          this.cdr.detectChanges(); // Detecta mudanças no componente
          this.toastr.success('Professores foram carregados com Sucesso!');
        },
        error: (error: any) => {
          this.toastr.error('Professores não carregados!');
          console.log(error);
        },
        complete: () => this.spinner.hide(),
      });
  }

  ngOnInit() {
    this.carregarProfessores();
  }

  ngOnDestroy(): void {
    this.unsubscriber.next();
    this.unsubscriber.complete();
  }

  disciplinaConcat(disciplinas: Disciplina[]) {
    return Util.nomeConcat(disciplinas);
  }


}
