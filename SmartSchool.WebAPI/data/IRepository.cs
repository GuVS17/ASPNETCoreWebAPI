using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.models;

namespace SmartSchool.WebAPI.data
{
    public interface IRepository 
    {

        void Add<T>(T entity) where T : class; //O Add está esperando um tipo que vai ser sempre uma classe. O entity pode ser por exemplo o Aluno
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        // ALUNOS 
        Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);   
        IEnumerable<Aluno> GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAllAlunosByDisciplinaId(int DisciplinaId, bool includeProfessor = false);
        Aluno GetAlunosById(int alunoId, bool includeProfessor = false);


        // PROFESSORES
        public Task<PageList<Professor>> GetAllProfessoresAsync(PageParamsProf pageParamsProf, bool includeAlunos = false);
        IEnumerable<Professor> GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int DisciplinaId, bool includeAlunos = false);
        Professor GetProfessorById(int professorId, bool includeAlunos = false);
    }
}