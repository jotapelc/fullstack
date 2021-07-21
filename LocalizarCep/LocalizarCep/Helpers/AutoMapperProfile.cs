using AutoMapper;
using LocalizarCep.Aplicacao.DTO;
using LocalizarCep.Dominio;
using LocalizarCep.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizarCep.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CEP, CEPDTO>();
            CreateMap<CEP, CEPDTO>().ReverseMap();

            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
