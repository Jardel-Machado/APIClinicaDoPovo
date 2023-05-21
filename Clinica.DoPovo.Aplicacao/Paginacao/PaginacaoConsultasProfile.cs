using AutoMapper;
using Clinica.DoPovo.Dominio.Util;

namespace Clinica.DoPovo.Aplicacao.Paginacao;

public class PaginacaoConsultasProfile : Profile
{
    public PaginacaoConsultasProfile()
    {
        CreateMap(typeof(PaginacaoConsulta<>), typeof(PaginacaoConsulta<>));
    }
}
