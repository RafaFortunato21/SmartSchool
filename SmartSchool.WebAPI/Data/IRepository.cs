using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Aluno[] GetAllAlunos(bool includeProfessor  = false);
        Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);


        Aluno[] GetAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
        Aluno GetAlunoById(int alunoId, bool includeProfessor  = false);

        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetProfessoresByDisciplinaId(int disciplicaId, bool includeAlunos  = false);
        Professor GetProfessorById(int professorId, bool includeAlunos  = false);

        
    }
}