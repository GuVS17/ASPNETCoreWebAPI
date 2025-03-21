using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.models;

namespace SmartSchool.WebAPI.Controllers
{

  [ApiController]
  [Route("api/[Controller]")]

  public class ProfessorController : ControllerBase
  {
    private readonly IRepository _repo;
    private readonly IMapper _mapper;

    public ProfessorController(IRepository repo,
                                IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;
    }

    [HttpGet]

    public IActionResult Get()
    {
      var professores = _repo.GetAllProfessores(true);
      return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
    }

    // [HttpGet("getRegister")]

    // public IActionResult getRegister()   // PEGAR O OBJETO VAZIO
    // {
    //   return Ok(new ProfessorRegistrarDto());
    // }

    // api/professor
    [HttpGet("{id}")]

    public IActionResult GetById(int id)
    {
      var professor = _repo.GetProfessorById(id, false);
      if (professor == null) return BadRequest("Professor não existe");

      var professorDto = _mapper.Map<ProfessorDto>(professor);

      return Ok(professorDto);
    }

    [HttpPost]

    public IActionResult Post(ProfessorRegistrarDto model)
    {

      var professor = _mapper.Map<Professor>(model);

      _repo.Add(professor);
      if (_repo.SaveChanges())
      {
        return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
      }
      return BadRequest("Professor não cadastrado");
    }

    [HttpPut("{id}")]

    public IActionResult Put(int id, ProfessorRegistrarDto model)
    {

      var professor = _repo.GetProfessorById(id, false);
      if (professor == null) return BadRequest("Professor não existe");

      _mapper.Map(model, professor);

      _repo.Update(professor);
      if (_repo.SaveChanges())
      {
        return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
      }
      return BadRequest("Professor não atualizado");
    }

    [HttpPatch("{id}")]

    public IActionResult Patch(int id, ProfessorRegistrarDto model)
    {

      var professor = _repo.GetProfessorById(id, false);
      if (professor == null) return BadRequest("Professor não existe");

      _mapper.Map(model, professor);

      _repo.Update(professor);
      if (_repo.SaveChanges())
      {
        return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
      }
      return BadRequest("Professor não atualizado");
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {

      var professor = _repo.GetProfessorById(id);
      if (professor == null) return BadRequest("Professor não existe");

      _repo.Delete(professor);
      if (_repo.SaveChanges())
      {
        return Ok("Professor Apagado");
      }
      return BadRequest("Professor não apagado");
    }
  }
}
