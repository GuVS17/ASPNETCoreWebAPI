using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.models
{
    public class Disciplina
    {
    public Disciplina() {}

    public Disciplina(int id, string nome, int professorId, int cursoId) 
    {
            this.Id = id;
            this.Nome = nome;
            this.ProfessorId = professorId;
            this.CursoId = cursoId;
    }
    public int Id { get; set; }
    public string Nome { get; set; }
    public int CargaHoraria { get; set; }
    public int? PrerequisitoId { get; set; } = null;  // Preenchimento não obrigatório 
    public Disciplina Prerequisito { get; set; }
    public int ProfessorId { get; set; }
    public Professor Professor { get; set; }
    public int CursoId { get; set; }       // Preenchimento obrigatório
    public Curso Curso { get; set; }      // Colocando que a disciplina vai ser cadastrada para um determinado curso


    public IEnumerable<AlunoDisciplina> AlunosDisciplinas  { get; set; }
    }
}