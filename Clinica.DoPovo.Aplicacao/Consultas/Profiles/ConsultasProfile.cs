using AutoMapper;
using Clinica.DoPovo.DataTransfer.Consultas.Request;
using Clinica.DoPovo.DataTransfer.Consultas.Response;
using Clinica.DoPovo.Dominio.Consultas.Entidades;
using Clinica.DoPovo.Dominio.Consultas.Repositorios.Filtros;
using Clinica.DoPovo.Dominio.Consultas.Servicos.Comandos;

namespace Clinica.DoPovo.Aplicacao.Consultas.Profiles;

public class ConsultasProfile : Profile
{
    public ConsultasProfile()
    {
        CreateMap<Consulta, ConsultaResponse>()
        .ForMember(x => x.NomePaciente, y => y.MapFrom(z => z.Paciente.Nome))
        .ForMember(x => x.NomeMedico, y => y.MapFrom(z => z.Medico.Nome))
        .ForMember(x => x.DescricaoEspecialidade, y => y.MapFrom(z => z.Especialidade.Descricao));

        CreateMap<ConsultaListarRequest, ConsultaListarFiltro>();        

        CreateMap<ConsultaEditarRequest, ConsultaEditarComando>();

        CreateMap<ConsultaInserirRequest, ConsultaInstanciarComando>();
    }
}
