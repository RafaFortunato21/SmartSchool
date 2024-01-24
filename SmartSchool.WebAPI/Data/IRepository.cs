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
        Aluno[] GetAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
        Aluno GetAlunoById(int alunoId, bool includeProfessor  = false);

        Professor[] GetAllProfessores(bool includeProfessor = false);
        Professor[] GetProfessoresByDisciplinaId(int disciplicaId, bool includeProfessor  = false);
        Professor GetProfessorById(int professorId, bool includeProfessor  = false);

        
    }
}