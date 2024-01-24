namespace SmartSchool.WebAPI.V1.Dtos
{
    public class ProfessorDTO
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int TempoComoProfessor { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
    }
}
