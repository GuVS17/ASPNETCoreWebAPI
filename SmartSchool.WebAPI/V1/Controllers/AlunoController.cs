using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.data;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.models;
using SmartSchool.WebAPI.V1.Dtos;

namespace SmartSchool.WebAPI.V1.Controllers
{

  [ApiController]
  [ApiVersion("1.0")]
  [Route("api/v{version:ApiVersion}/[Controller]")]

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

    /// <summary>
    /// Busca todos os Alunos
    /// </summary>
    /// <returns></returns>

    [HttpGet]

    public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
    {
      var alunos = await _repo.GetAllAlunosAsync(pageParams);

      var alunosResult = _mapper.Map<IEnumerable<AlunoDto>>(alunos);

      Response.AddPagination(alunos.CurrentPage, alunos.PageSize, alunos.TotalCount, alunos.TotalPages );

      return Ok(alunosResult);
    }

    //  [HttpGet("getRegister")]

    //  public IActionResult getRegister()      //Para pegar o objeto vazio
    //  {
    //    return Ok(new AlunoRegistrarDto());
    //  }
    
    /// <summary>
    /// Busca o Aluno por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]               // api/aluno

    public IActionResult GetById(int id)       
    {
      var aluno = _repo.GetAlunosById(id);
      if (aluno == null) return BadRequest("Aluno não existe");

      var alunoDto = _mapper.Map<AlunoDto>(aluno);

      return Ok(alunoDto);
    }

    /// <summary>
    /// Inclui um novo Aluno
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Atualiza os dados do Aluno
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Atualiza os dados do Aluno
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Apaga o Aluno 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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