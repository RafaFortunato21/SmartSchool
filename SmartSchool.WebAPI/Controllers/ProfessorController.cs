using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data.Context;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;


        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _context.Professores;
            return Ok(professores);
        }
        
        [HttpGet("{professorId}")]
        public IActionResult Get(int professorId)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == professorId);

            if(professor == null) return NotFound();

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Put(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();

            return Ok(professor);
        }


        [HttpPut("{professorId}")]
        public IActionResult Put(int professorId, Professor professor)
        {
            var professorResult = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == professorId);

            if(professorResult == null) return BadRequest("Professor não encontrado.");

            _context.Update(professor);
            _context.SaveChanges();

            return Ok(professor);
        }
         [HttpPatch("{professorId}")]
        public IActionResult Patch(int professorId, Professor professor)
        {
            var professorResult = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == professorId);

            if(professorResult == null) return BadRequest("Professor não encontrado.");

            _context.Update(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        [HttpDelete("{professorId}")]
        public IActionResult Delete(int professorId)
        {
            var professorResult = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == professorId);

            if(professorResult == null) return BadRequest("Professor não encontrado.");

            _context.Remove(professorResult);
            _context.SaveChanges();

            return Ok("Professor deletado com sucesso!");
        }



    }
}