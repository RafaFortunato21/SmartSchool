using AutoMapper;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.V2.Dtos;

namespace SmartSchool.WebAPI.V2
{
    public class SmartSchoolProfile2 : Profile
    {
        public SmartSchoolProfile2()
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
        }
    }
}