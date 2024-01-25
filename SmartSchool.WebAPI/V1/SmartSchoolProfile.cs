using AutoMapper;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.V1.Dtos;

namespace SmartSchool.WebAPI.V1
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDTO>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}" )
                
                ).ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNascimento.GetCurrentAge())
                );

                CreateMap<AlunoDTO, Aluno>();
                
                CreateMap<Aluno, AlunoRegistrarDTO>().ReverseMap();

            CreateMap<Professor, ProfessorDTO>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")

                ).ForMember(
                    dest => dest.TempoComoProfessor,
                    opt => opt.MapFrom(src => src.DataInicio.GetTimeOfService())
                );

            CreateMap<Professor, ProfessorRegistrarDTO>().ReverseMap();
        }
    }
}