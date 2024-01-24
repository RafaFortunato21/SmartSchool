using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Data.Context;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {

        private readonly IRepository _repository;

        public ProfessorController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repository.GetAllProfessores(true);
            return Ok(professores);
        }

        [HttpGet("{professorId}")]
        public IActionResult Get(int professorId)
        {
            var professor = _repository.GetProfessorById(professorId);

            if (professor == null) return NotFound();

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Put(Professor professor)
        {
            _repository.Add(professor);

            return _repository.SaveChanges()
                    ? Ok(professor)
                    : BadRequest("Professor não cadastrado");
        }


        [HttpPut("{professorId}")]
        public IActionResult Put(int professorId, Professor professor)
        {
            var professorResult = _repository.GetProfessorById(professorId);

            if (professorResult == null) return BadRequest("Professor não encontrado.");

            _repository.Update(professor);

            return _repository.SaveChanges()
                    ? Ok(professor)
                    : BadRequest("Aluno não atualizado");

        }

        [HttpPatch("{professorId}")]
        public IActionResult Patch(int professorId, Professor professor)
        {
            var professorResult = _repository.GetProfessorById(professorId);

            if (professorResult == null) return BadRequest("Professor não encontrado.");

            _repository.Update(professor);

            return _repository.SaveChanges()
                    ? Ok(professor)
                    : BadRequest("Aluno não atualizado");
        }

        [HttpDelete("{professorId}")]
        public IActionResult Delete(int professorId)
        {
            var professorResult = _repository.GetProfessorById(professorId);

            if (professorResult == null) return BadRequest("Professor não encontrado.");

            _repository.Delete(professorResult);

            return _repository.SaveChanges()
                    ? Ok("Aluno Deletado.")
                    : BadRequest("Aluno não deletado.");

        }



    }
}