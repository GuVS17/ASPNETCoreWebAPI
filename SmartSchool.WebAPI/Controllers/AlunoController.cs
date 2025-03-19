using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.models;

namespace SmartSchool.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]

    public class AlunoController : ControllerBase
    {
          public List<Aluno> Alunos = new List<Aluno>() {
        new Aluno() {
          Id = 1,
          Nome = "Gustavo",
          Sobrenome = "Vieira",
          Telefone = "88559966",
        },
        new Aluno() {
          Id = 2,
          Nome = "Sueli",
          Sobrenome = "Santos",
          Telefone = "88557799",
        },
        new Aluno() {
          Id = 3,
          Nome = "Rodrigo",
          Sobrenome = "V.S.",
          Telefone = "88559966",
        }
      };
      
          public AlunoController() {}

          [HttpGet]

          public IActionResult Get() {

            return Ok(Alunos);
          }

          // api/aluno/ById/1
          [HttpGet("byId/{id}")] // Ou [HttpGet("{id: int}")]

          public IActionResult GetById(int id) {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null ) return BadRequest("Aluno não existe");

            return Ok(aluno);
          }

          // api/aluno/byName?nome=Gustavo&sobrenome=Vieira
          [HttpGet("byName")]

          public IActionResult GetByName(string Nome, string Sobrenome) {
            var aluno = Alunos.FirstOrDefault(
             a => a.Nome.Contains(Nome) && a.Sobrenome.Contains(Sobrenome));
            if (aluno == null ) return BadRequest("Aluno não existe");

            return Ok(aluno);
          }

          [HttpPost]

          public IActionResult Post(Aluno aluno) {
            
             return Ok(aluno);
          }

          [HttpPut("{id}")]

          public IActionResult Put(int id, Aluno aluno) {
            
             return Ok(aluno);
          }

          [HttpPatch("{id}")]

          public IActionResult Patch(int id, Aluno aluno) {
            
             return Ok(aluno);
          }

          [HttpDelete("{id}")]

          public IActionResult Delete(int id) {
            
             return Ok();
          }
    }
}