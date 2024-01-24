using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Data.Context;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repository.GetAllAlunos(true);

            var alunosResult = _mapper.Map<AlunoDTO[]>(alunos);

            return Ok(alunosResult);
        }

        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new AlunoRegistrarDTO());
        }

        [HttpGet("{alunoId}")]
        public IActionResult Get(int alunoId)
        {
            var aluno = _repository.GetAlunoById(alunoId,true);

            if (aluno == null) return NotFound();

            return Ok(_mapper.Map<AlunoDTO>(aluno));
        }

        [HttpPost]
        public IActionResult Post(AlunoRegistrarDTO aluno)
        {
            var alunoEntity = _mapper.Map<Aluno>(aluno);

            _repository.Add(alunoEntity);

            return _repository.SaveChanges() 
                    ? Created($"/api/aluno/{aluno.Id}", _mapper.Map<AlunoRegistrarDTO>(alunoEntity))
                    : BadRequest("Aluno não cadastrado.");
        }

        [HttpPut("{alunoId}")]
        public IActionResult Put(int alunoId, AlunoRegistrarDTO model)
        {
            
            var aluno = _repository.GetAlunoById(alunoId);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _mapper.Map(model, aluno);

            _repository.Update(aluno);

            return _repository.SaveChanges() 
                    ? Created($"/api/aluno/{aluno.Id}", _mapper.Map<AlunoDTO>(aluno))
                    : BadRequest("Aluno não atualizado.");
        }

        [HttpPatch("{alunoId}")]
        public IActionResult Patch(int alunoId, AlunoRegistrarDTO model)
        {
             var aluno = _repository.GetAlunoById(alunoId);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _mapper.Map(model, aluno);

            _repository.Update(aluno);

            return _repository.SaveChanges() 
                    ? Created($"/api/aluno/{aluno.Id}", _mapper.Map<AlunoRegistrarDTO>(aluno))
                    : BadRequest("Aluno não atualizado.");
        }

        [HttpDelete("{alunoId}")]
        public IActionResult Delete(int alunoId)
        {
            var aluno = _repository.GetAlunoById(alunoId);
            if (aluno == null) return BadRequest();
            
             _repository.Delete (aluno);

            return _repository.SaveChanges() 
                    ? Ok("Aluno Deletado") 
                    : BadRequest("Aluno não Atualizado.");
        }
    }
}