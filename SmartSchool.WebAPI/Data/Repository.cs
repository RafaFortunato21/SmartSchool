using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data.Context;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;
        public Repository(SmartContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(d => d.Disciplina)
                             .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.Id);

            return query.ToArray();
        }

        public async Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(d => d.Disciplina)
                             .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.Id);

            if (!string.IsNullOrEmpty(pageParams.Nome))
                query = query.Where(a => a.Nome
                             .ToUpper()
                             .Contains(pageParams.Nome.ToUpper()) ||
                             a.Sobrenome.ToUpper()
                             .Contains(pageParams.Nome.ToUpper()));
            if (pageParams.Matricula > 0)
                query = query.Where(a => a.Matricula == pageParams.Matricula);

            if (pageParams.Ativo)
                query = query.Where(a => a.Ativo == pageParams.Ativo);

            return await PageList<Aluno>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public Aluno[] GetAlunosByDisciplinaId(int disciplinaId, bool includeDisciplina = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeDisciplina)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(d => d.Disciplina)
                             .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking()
                         .Where(a => a.AlunosDisciplinas.Any(a => a.DisciplinaId == disciplinaId))
                         .OrderBy(aluno => aluno.Id);

            return query.ToArray();
        }

        public Aluno GetAlunoById(int alunoId, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (incluirProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(d => d.Disciplina)
                             .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking()
                         .Where(a => a.Id == alunoId)
                         .OrderBy(aluno => aluno.Id);

            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(pd => pd.AlunosDisciplinas)
                             .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking()
                         .OrderBy(p => p.Id);

            return query.ToArray();




        }

        public Professor[] GetProfessoresByDisciplinaId(int disciplinaId, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(pd => pd.AlunosDisciplinas)
                             .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking()
                         .Where(professor => professor.Disciplinas.Any(d => d.Id == disciplinaId))
                         .OrderBy(p => p.Id);

            return query.ToArray();
        }

        public Professor GetProfessorById(int professorId, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(pd => pd.AlunosDisciplinas)
                             .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking()
                         .Where(professor => professor.Id == professorId)
                         .OrderBy(p => p.Id);

            return query.FirstOrDefault();
        }


    }
}