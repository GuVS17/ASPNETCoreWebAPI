using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.data;
using SmartSchool.WebAPI.models;

namespace SmartSchool.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]

    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;

        public AlunoController(IRepository repo) // Vou receber o IRepository quando chamar o AlunoController, que vai pegar pelo Startup.cs
        {
            _repo = repo;
        }

        [HttpGet]

          public IActionResult Get() {

            var result = _repo.GetAllAlunos(true);
            return Ok(result);
          }

          // api/aluno
          [HttpGet("{id}")] 

          public IActionResult GetById(int id) {
            var aluno = _repo.GetAlunosById(id);
            if (aluno == null ) return BadRequest("Aluno não existe");

            return Ok(aluno);
          }

          [HttpPost]

          public IActionResult Post(Aluno aluno) {

            _repo.Add(aluno);
            if (_repo.SaveChanges()){
              return Ok(aluno);
            }
            return BadRequest("Aluno não cadastrado");
          }

          [HttpPut("{id}")]

          public IActionResult Put(int id, Aluno aluno) {
            
            var alu = _repo.GetAlunosById(id);
            if (alu == null ) return BadRequest("Aluno não existe");
            
            _repo.Update(aluno);
            if (_repo.SaveChanges()){
              return Ok(aluno);
            }
            return BadRequest("Aluno não atualizado");
          }

          [HttpPatch("{id}")]

          public IActionResult Patch(int id, Aluno aluno) {
            
            var alu = _repo.GetAlunosById(id);
            if (alu == null ) return BadRequest("Aluno não existe");

            _repo.Update(aluno);
            if (_repo.SaveChanges()){
              return Ok(aluno);
            }
            return BadRequest("Aluno não atualizado");
          }

          [HttpDelete("{id}")]

          public IActionResult Delete(int id) {
            
            var alu = _repo.GetAlunosById(id);
            if (alu == null ) return BadRequest("Aluno não existe");

            _repo.Delete(alu);
            if (_repo.SaveChanges()){
              return Ok("Aluno apagado");
            }
            return BadRequest("Aluno não apagado");
          }
    }
}