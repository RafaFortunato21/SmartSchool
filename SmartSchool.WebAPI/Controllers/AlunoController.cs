using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Data.Context;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;

        public AlunoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAllAlunos(true));
        }

        [HttpGet("{alunoId}")]
        public IActionResult Get(int alunoId)
        {
            var aluno = _repository.GetAlunoById(alunoId,true);

            if (aluno == null) return NotFound();

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repository.Add(aluno);

            return _repository.SaveChanges() 
                    ? Ok(aluno) 
                    : BadRequest("Aluno não cadastrado.");
        }

        [HttpPut("{alunoId}")]
        public IActionResult Put(int alunoId, Aluno aluno)
        {
            
            var alunoResult = _repository.GetAlunoById(alunoId);
            if (alunoResult == null) return BadRequest("Aluno não encontrado");

            _repository.Update(aluno);

            return _repository.SaveChanges() 
                    ? Ok(aluno) 
                    : BadRequest("Aluno não atualizado.");
        }

        [HttpPatch("{alunoId}")]
        public IActionResult Patch(int alunoId, Aluno aluno)
        {
            var alunoResult = _repository.GetAlunoById(alunoId);
               
            if (alunoResult == null) return BadRequest("Aluno não encontrado");


             _repository.Update(aluno);

            return _repository.SaveChanges() 
                    ? Ok(aluno) 
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