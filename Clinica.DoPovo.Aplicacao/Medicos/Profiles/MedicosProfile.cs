using AutoMapper;
using Clinica.DoPovo.DataTransfer.Medicos.Request;
using Clinica.DoPovo.DataTransfer.Medicos.Response;
using Clinica.DoPovo.Dominio.Medicos.Entidades;
using Clinica.DoPovo.Dominio.Medicos.Repositorios.Filtros;
using Clinica.DoPovo.Dominio.Medicos.Servicos.Comandos;

namespace Clinica.DoPovo.Aplicacao.Medicos.Profiles;

public class MedicosProfile : Profile
{
    public MedicosProfile()
    {
        CreateMap<Medico, MedicoResponse>();

        CreateMap<MedicoListarRequest, MedicoListarFiltro>();

        CreateMap<MedicoAdicionarEspecialidadeRequest, MedicoAdicionarEspecialidadeComando>();

        CreateMap<MedicoRemoverEspecialidadeRequest, MedicoRemoverEspecialidadeComando>();

        CreateMap<MedicoEditarRequest, MedicoEditarComando>();

        CreateMap<MedicoInserirRequest, MedicoInstanciarComando>();
    }
}
