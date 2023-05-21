using AutoMapper;
using Clinica.DoPovo.DataTransfer.Pacientes.Request;
using Clinica.DoPovo.DataTransfer.Pacientes.Response;
using Clinica.DoPovo.Dominio.Pacientes.Entidades;
using Clinica.DoPovo.Dominio.Pacientes.Servicos.Comandos;
using Clinica.DoPovo.Repositorios.Filtros;

namespace Clinica.DoPovo.Aplicacao.Pacientes.Profiles;

public class PacientesProfile : Profile
{
    public PacientesProfile()
    {
        CreateMap<Paciente, PacienteResponse>();

        CreateMap<PacienteListarRequest, PacienteListarFiltro>();

        CreateMap<PacienteInserirRequest, PacienteInstanciarComando>();

        CreateMap<PacienteEditarRequest, PacienteEditarComando>();
    }
}
