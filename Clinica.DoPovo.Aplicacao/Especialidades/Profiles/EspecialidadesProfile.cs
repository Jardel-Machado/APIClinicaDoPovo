using AutoMapper;
using Clinica.DoPovo.DataTransfer.Especialidades.Request;
using Clinica.DoPovo.DataTransfer.Especialidades.Response;
using Clinica.DoPovo.Dominio.Especialidades.Entidades;
using Clinica.DoPovo.Dominio.Especialidades.Repositorios.Filtros;
using Clinica.DoPovo.Dominio.Especialidades.Servicos.Comandos;

namespace Clinica.DoPovo.Aplicacao.Especialidades.Profiles;

public class EspecialidadesProfile : Profile
{
    public EspecialidadesProfile()
    {
        CreateMap<Especialidade, EspecialidadeResponse>();

        CreateMap<EspecialidadeListarRequest, EspecialidadeListarFiltro>();

        CreateMap<EspecialidadeEditarRequest, EspecialidadeEditarComando>();

        CreateMap<EspecialidadeInserirRequest, EspecialidadeInstanciarComando>();
    }
}
