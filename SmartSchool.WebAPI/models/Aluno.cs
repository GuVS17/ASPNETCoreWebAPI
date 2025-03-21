using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.models
{
    public class Aluno
    {
      public Aluno() {}

      public Aluno(int id, int matricula, string nome, string sobrenome, string telefone, DateTime dataNasc) //Campos obrigatorios
      {
            this.Id = id;
            this.Matricula = matricula;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
            this.DataNasc = dataNasc;
   
      }

      public int Id { get; set; }
      public int Matricula { get; set; }
      public string Nome { get; set; }
      public string Sobrenome { get; set; } 
      public string Telefone { get; set; }  
      public DateTime DataNasc { get; set;}
      public DateTime DataInic { get; set;} = DateTime.Now;
      public DateTime? DataFim { get; set; } = null;     // ? Pra máquina entender que o campo vai ser null
      public bool Ativo { get; set; } = true;          // Sempre que não houver true ou false, e for atribuido, vai ser sempre true


      public IEnumerable<AlunoDisciplina> AlunosDisciplinas  { get; set; }
}
}