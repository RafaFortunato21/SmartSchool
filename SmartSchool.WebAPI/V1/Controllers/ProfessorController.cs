using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Data.Context;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.V1.Dtos;

namespace SmartSchool.WebAPI.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {

        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repository.GetAllProfessores(true);

            return Ok(_mapper.Map<ProfessorDTO[]>(professores));
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return Ok(new ProfessorRegistrarDTO());
        }

        [HttpGet("{professorId}")]
        public IActionResult Get(int professorId)
        {
            var professor = _repository.GetProfessorById(professorId);

            if (professor == null) return NotFound();

            return Ok(_mapper.Map<ProfessorDTO>(professor));
        }

        [HttpPost]
        public IActionResult Put(ProfessorRegistrarDTO model)
        {
            var professor = _mapper.Map<Professor>(model);
            _repository.Add(professor);



            return _repository.SaveChanges()
                    ? Ok(_mapper.Map<ProfessorDTO>(professor))
                    : BadRequest("Professor não cadastrado");
        }


        [HttpPut("{professorId}")]
        public IActionResult Put(int professorId, ProfessorRegistrarDTO model)
        {
            var professor = _repository.GetProfessorById(professorId);

            if (professor == null) return BadRequest("Professor não encontrado.");

            _mapper.Map(model, professor);

            _repository.Update(professor);

            return _repository.SaveChanges()
                    ? Ok(_mapper.Map<ProfessorDTO>(professor))
                    : BadRequest("Aluno não atualizado");

        }

        [HttpPatch("{professorId}")]
        public IActionResult Patch(int professorId, ProfessorRegistrarDTO model)
        {
            var professor = _repository.GetProfessorById(professorId);

            if (professor == null) return BadRequest("Professor não encontrado.");

            _mapper.Map(model, professor);

            _repository.Update(professor);

            return _repository.SaveChanges()
                    ? Ok(_mapper.Map<ProfessorDTO>(professor))
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