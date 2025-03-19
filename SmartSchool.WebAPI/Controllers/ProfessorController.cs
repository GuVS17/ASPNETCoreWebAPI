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

    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]

    public IActionResult Get() {

      return Ok(_context.Professores);
    }

    // api/aluno/ById/1
    [HttpGet("byId/{id}")] // Ou [HttpGet("{id: int}")]

    public IActionResult GetById(int id) {
      var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
      if (professor == null ) return BadRequest("Professor não existe");
      return Ok(professor);
    }

    // api/aluno/byName?nome=Gustavo&sobrenome=Vieira
    [HttpGet("byName")]

    public IActionResult GetByName(string Nome) {
      var professor = _context.Professores.FirstOrDefault(
       a => a.Nome.Contains(Nome));
      if (professor == null ) return BadRequest("Professor não existe");

      return Ok(professor);
    }

    [HttpPost]

    public IActionResult Post(Professor professor) {

      _context.Add(professor);
      _context.SaveChanges();
      return Ok(professor);
    }

    [HttpPut("{id}")]

    public IActionResult Put(int id, Professor professor) {
            
      var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id); // Pode dar um erro que a aplicação bloqueia a informação que foi puxada e o AsNoTracking não deixa travar a aplicação.
      if (prof == null ) return BadRequest("Professor não existe");
            
      _context.Update(professor);
      _context.SaveChanges();
       return Ok(professor);
    }

    [HttpPatch("{id}")]

    public IActionResult Patch(int id, Professor professor) {
            
      var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
      if (prof == null ) return BadRequest("Professor não existe");

      _context.Update(professor);
      _context.SaveChanges();
       return Ok(professor);
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id) {
            
      var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
      if (professor == null ) return BadRequest("Professor não existe");

      _context.Remove(professor);
      _context.SaveChanges();
        return Ok("Professor Apagado");
      }     
    }
}
    