using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SmartSchool.WebAPI.models;
using SmartSchool.WebAPI.V1.Dtos;

namespace SmartSchool.WebAPI.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()      //Toda vez que trabalhar com o Aluno, vai mapear com o AlunoDto
                .ForMember(
                    dest => dest.Nome,        //Estou pegando do Aluno e mandando para o DTO
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")    //Juntando o Nome e Sobrenome
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge())  //Estou mandando o calculo do GetCurrentAge para a Idade 
                );
            
            CreateMap<AlunoDto, Aluno>();

            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();

            CreateMap<Professor, ProfessorDto>()      //Toda vez que trabalhar com o Professor, vai mapear com o ProfessorDto
                .ForMember(
                    dest => dest.Nome,        
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                    );

            CreateMap<ProfessorDto, Professor>();   

            CreateMap<Professor, ProfessorRegistrarDto>().ReverseMap();
        }
        
    }
}