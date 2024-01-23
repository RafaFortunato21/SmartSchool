using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data.Context;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>();
        private readonly SmartContext _context;


        public AlunoController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        [HttpGet("{alunoId}")]
        public IActionResult Get(int alunoId)
        {
            var aluno = _context.Alunos.Find(alunoId);

            if (aluno == null) return NotFound();

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{alunoId}")]
        public IActionResult Put(int alunoId, Aluno aluno)
        {
            var alunoResult = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == alunoId);
            if (alunoResult == null) return BadRequest("Aluno não encontrado");

            _context.Alunos.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPatch("{alunoId}")]
        public IActionResult Patch(int alunoId, Aluno aluno)
        {
            var alunoResult = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == alunoId);
              
            if (alunoResult == null) return BadRequest("Aluno não encontrado");


            _context.Alunos.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{alunoId}")]
        public IActionResult Delete(int alunoId)
        {
            var aluno = _context.Alunos.Find(alunoId);

            if (aluno == null) return BadRequest();
            
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }
    }
}