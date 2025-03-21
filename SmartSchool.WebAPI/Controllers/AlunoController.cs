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

  public class AlunoController : ControllerBase
  {
    private readonly IRepository _repo;
    private readonly IMapper _mapper;

    public AlunoController(IRepository repo,  // Vou receber o IRepository quando chamar o AlunoController, que vai pegar pelo Startup.cs
                           IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }

    [HttpGet]

    public IActionResult Get()
    {
      var alunos = _repo.GetAllAlunos(true);
      return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
    }

    //  [HttpGet("getRegister")]

    //  public IActionResult getRegister()      //Para pegar o objeto vazio
    //  {
    //    return Ok(new AlunoRegistrarDto());
    //  }

    // api/aluno
    [HttpGet("{id}")]

    public IActionResult GetById(int id)
    {
      var aluno = _repo.GetAlunosById(id);
      if (aluno == null) return BadRequest("Aluno não existe");

      var alunoDto = _mapper.Map<AlunoDto>(aluno);

      return Ok(alunoDto);
    }

    [HttpPost]

    public IActionResult Post(AlunoRegistrarDto model)
    {

      var aluno = _mapper.Map<Aluno>(model);

      _repo.Add(aluno);
      if (_repo.SaveChanges())
      {
        return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
      }
      return BadRequest("Aluno não cadastrado");
    }

    [HttpPut("{id}")]

    public IActionResult Put(int id, AlunoRegistrarDto model)
    {

      var aluno = _repo.GetAlunosById(id);
      if (aluno == null) return BadRequest("Aluno não existe");

      _mapper.Map(model, aluno);

      _repo.Update(aluno);
      if (_repo.SaveChanges())
      {
        return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
      }
      return BadRequest("Aluno não atualizado");
    }

    [HttpPatch("{id}")]

    public IActionResult Patch(int id, AlunoRegistrarDto model)
    {

      var aluno = _repo.GetAlunosById(id);
      if (aluno == null) return BadRequest("Aluno não existe");

      _mapper.Map(model, aluno);

      _repo.Update(aluno);
      if (_repo.SaveChanges())
      {
        return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
      }
      return BadRequest("Aluno não atualizado");
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {

      var aluno = _repo.GetAlunosById(id);
      if (aluno == null) return BadRequest("Aluno não existe");

      _repo.Delete(aluno);
      if (_repo.SaveChanges())
      {
        return Ok("Aluno apagado");
      }
      return BadRequest("Aluno não apagado");
    }
  }
}