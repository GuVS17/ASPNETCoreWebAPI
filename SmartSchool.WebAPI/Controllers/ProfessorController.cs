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
        private readonly IRepository _repo;

        public ProfessorController( IRepository repo)
        {
             _repo = repo;
        }

        [HttpGet]

    public IActionResult Get() 
    {
      var result = _repo.GetAllProfessores(true);
      return Ok(result);
    }

    // api/professor
    [HttpGet("{id}")] 

    public IActionResult GetById(int id) 
    {
      var professor = _repo.GetProfessorById(id, false);
      if (professor == null ) return BadRequest("Professor não existe");
      return Ok(professor);
    }

    [HttpPost]

    public IActionResult Post(Professor professor) {

      _repo.Add(professor);
      if (_repo.SaveChanges()){
        return Ok(professor);
      }
      return BadRequest("Professor não cadastrado");
    }

    [HttpPut("{id}")]

    public IActionResult Put(int id, Professor professor) {
            
      var prof = _repo.GetProfessorById(id, false);
      if (prof == null ) return BadRequest("Professor não existe");
            
      _repo.Update(professor);
      if (_repo.SaveChanges())
      {
        return Ok(professor);
      }
      return BadRequest("Professor não atualizado");
    }

    [HttpPatch("{id}")]

    public IActionResult Patch(int id, Professor professor) {
            
      var prof = _repo.GetProfessorById(id, false);
      if (prof == null ) return BadRequest("Professor não existe");

      _repo.Update(professor);
      if (_repo.SaveChanges()){
        return Ok(professor);
      }
      return BadRequest("Professor não atualizado");
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id) {
            
      var professor = _repo.GetProfessorById(id);
      if (professor == null ) return BadRequest("Professor não existe");

      _repo.Delete(professor);
      if (_repo.SaveChanges()){
        return Ok("Professor Apagado");
      }
      return BadRequest("Professor não apagado");
      }     
    }
}
    