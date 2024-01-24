namespace SmartSchool.WebAPI.V1.Dtos
{
    public class AlunoRegistrarDTO
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataEncerramento { get; set; } = null;
        public bool Ativo { get; set; } = true;

    }
}