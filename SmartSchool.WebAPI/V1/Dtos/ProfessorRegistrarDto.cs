using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSchool.WebAPI.models;

namespace SmartSchool.WebAPI.V1.Dtos
{
    public class ProfessorRegistrarDto
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string? Telefone { get; set; } = null;
        public DateTime DataInic { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null; 
        public bool Ativo { get; set; } = true;        
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}