using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Data.Context;
using SmartSchool.WebAPI.V2.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Método responsável para retornar todos os meus alunos
        /// </summary>
        /// <returns></returns> <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repository.GetAllAlunos(true);

            var alunosResult = _mapper.Map<AlunoDTO[]>(alunos);

            return Ok(alunosResult);
        }


        /// <summary>
        /// Método responsável por retornar apenas um Aluno atráves do ID.
        /// </summary>
        /// <param name="alunoId"></param>
        /// <returns></returns>
        [HttpGet("{alunoId}")]
        public IActionResult Get(int alunoId)
        {
            var aluno = _repository.GetAlunoById(alunoId,true);

            if (aluno == null) return NotFound();

            return Ok(_mapper.Map<AlunoDTO>(aluno));
        }
        
    }
}