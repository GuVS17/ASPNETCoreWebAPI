using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.models
{
    public class Professor
    {
        public Professor() {}

        public Professor(int id, int registro, string nome, string sobrenome) 
        {
            this.Id = id;
            this.Registro = registro;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
        }
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string? Telefone { get; set; } = null;
        public DateTime DataInic { get; set;} = DateTime.Now;
        public DateTime? DataFim { get; set; } = null; // ? Pra máquina entender que o campo vai ser null
        public bool Ativo { get; set; } = true;        // Sempre que não houver true ou false, e for atribuido, vai ser sempre true
        public IEnumerable<Disciplina> Disciplinas { get; set; }

    }
}