using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.data;
using SmartSchool.WebAPI.models;
using SmartSchool.WebAPI.V1.Dtos;

namespace SmartSchool.WebAPI.V1.Controllers
{

  [ApiController]
  [ApiVersion("1.0")]
  [Route("api/v{version:ApiVersion}/[Controller]")]

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

    /// <summary>
    /// Busca todos os Professores
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Busca o Professor pelo Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]       // api/professor

    public IActionResult GetById(int id)
    {
      var professor = _repo.GetProfessorById(id, false);
      if (professor == null) return BadRequest("Professor não existe");

      var professorDto = _mapper.Map<ProfessorDto>(professor);

      return Ok(professorDto);
    }

    /// <summary>
    /// Inclui um novo Professor
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Atualiza os dados do Professor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Atualiza os dados do Professor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>

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

    /// <summary>
    /// Apaga o Professor
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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
