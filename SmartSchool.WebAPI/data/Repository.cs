using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.models;

namespace SmartSchool.WebAPI.data
{
    public class Repository : IRepository  // Se o IRepository aqui ficar dando erro depois que digitar os métodos, só colocar os nomes iguais estão aqui, no arquivo IRepository
    {

        private readonly SmartContext _context;
        public Repository(SmartContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class //Implementação dos metodos genericos 
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0); //Se salvou alguma coisa, retorna o true. Por ele ser booleano
        }

        public IEnumerable<Aluno> GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;      // Selecionando a tabela Alunos

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)  // Sobre a query, estou fazendo um join sobre AlunosDisciplinas
                             .ThenInclude(ad => ad.Disciplina)   // Outro Join aqui
                             .ThenInclude(d => d.Professor);     // E outro aqui
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);     // Pode dar um erro que a aplicação bloqueia a informação que foi puxada e o AsNoTracking não deixa travar a aplicação. Ordenação pelo Id 

            return query.ToArray();                              // Executando a query aqui 
        }

        public async Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;      // Selecionando a tabela Alunos

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)  // Sobre a query, estou fazendo um join sobre AlunosDisciplinas
                             .ThenInclude(ad => ad.Disciplina)   // Outro Join aqui
                             .ThenInclude(d => d.Professor);     // E outro aqui
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);     // Pode dar um erro que a aplicação bloqueia a informação que foi puxada e o AsNoTracking não deixa travar a aplicação. Ordenação pelo Id 

            if(!string.IsNullOrEmpty(pageParams.Nome))
                query = query.Where(aluno => aluno.Nome         //Verificando se o nome de determinado aluno contem no pageParams
                                                  .ToUpper()
                                                  .Contains(pageParams.Nome.ToUpper()) ||
                                             aluno.Sobrenome
                                                  .ToUpper()
                                                  .Contains(pageParams.Nome.ToUpper()));
                query = query.OrderBy(aluno => aluno.Nome);
                
            if (pageParams.Matricula > 0)
               query = query.Where(aluno => aluno.Matricula == pageParams.Matricula);  //Em determinado aluno, se for maior que 0 tem que ser igual aluno.Matricula
            
            if (pageParams.Ativo != null)
                query = query.Where(aluno => aluno.Ativo == (pageParams.Ativo != 0));
                
            //return await query.ToListAsync();                              // Executando a query aqui
            return await PageList<Aluno>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);      //Onde o primeiro número é o da página e o segundo é a quantidade de itens na página 
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int DisciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                        .OrderBy(a => a.Id)
                        .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == DisciplinaId));

            return query.ToArray();
        }

        public Aluno GetAlunosById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                        .OrderBy(a => a.Id)
                        .Where(aluno => aluno.Id == alunoId);

            return query.FirstOrDefault();  //Retorna só o primeiro ou último da query
        }

        public IEnumerable<Professor> GetAllProfessores(bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;      // Selecionando a tabela Alunos

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)  // Sobre a query, estou fazendo um join sobre AlunosDisciplinas
                             .ThenInclude(d => d.AlunosDisciplinas)   // Outro Join aqui
                             .ThenInclude(ad => ad.Aluno);     // E outro aqui
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);     // AsNoTracking para não travar o código se ele puxar algo antes. Ordenação pelo Id 

            return query.ToArray();
        }

        public async Task<PageList<Professor>> GetAllProfessoresAsync(PageParamsProf pageParamsProf, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;      // Selecionando a tabela Alunos

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)  // Sobre a query, estou fazendo um join sobre AlunosDisciplinas
                             .ThenInclude(d => d.AlunosDisciplinas)   // Outro Join aqui
                             .ThenInclude(ad => ad.Aluno);     // E outro aqui
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);     // AsNoTracking para não travar o código se ele puxar algo antes. Ordenação pelo Id 

            if (!string.IsNullOrEmpty(pageParamsProf.Nome))
                query = query.Where(prof => prof.Nome
                                                .ToUpper()
                                                .Contains(pageParamsProf.Nome.ToUpper()) ||
                                            prof.Sobrenome
                                                .ToUpper()
                                                .Contains(pageParamsProf.Nome.ToUpper()));
                query = query.OrderBy(prof => prof.Nome);
            
            if (pageParamsProf.Registro > 0)
                query = query.Where(prof => prof.Registro == pageParamsProf.Registro);
            
            if (pageParamsProf.Ativo != null)
                query = query.Where(prof => prof.Ativo == (pageParamsProf.Ativo != 0));

            return await PageList<Professor>.CreateAsync(query, pageParamsProf.PageNumber, pageParamsProf.PageSize);
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int DisciplinaId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(d => d.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                        .OrderBy(aluno => aluno.Id)
                        .Where(aluno => aluno.Disciplinas.Any(d => d.AlunosDisciplinas.Any(ad => ad.DisciplinaId == DisciplinaId)));     // Onde estou pesquisando a disciplinaId pelo join entre Professor e Disciplinas e depois entre AlunosDisciplinas e o Id da Disciplina

            return query.ToArray();
        }

        public Professor GetProfessorById(int professorId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(d => d.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                        .OrderBy(a => a.Id)
                        .Where(professor => professor.Id == professorId);

            return query.FirstOrDefault();
        }
    }
}