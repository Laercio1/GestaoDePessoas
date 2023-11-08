using AutoMapper;
using GestaoDePessoas.Application.ViewModels.Pessoa;
using GestaoDePessoas.Application.ViewModels.Produto;
using GestaoDePessoas.Dominio.PessoaRoot;

namespace GestaoDePessoas.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Pessoa, PessoaAdicionarViewModel>().ReverseMap();
            CreateMap<Pessoa, PessoaAtualizarViewModel>().ReverseMap();
            CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
        }
    }
}
