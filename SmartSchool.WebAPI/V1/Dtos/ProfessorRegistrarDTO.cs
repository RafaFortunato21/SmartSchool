﻿namespace SmartSchool.WebAPI.V1.Dtos
{
    public class ProfessorRegistrarDTO
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataEncerramento { get; set; } = null;
        public bool Ativo { get; set; } = true;
    }
}
