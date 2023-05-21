using AutoMapper;
using Clinica.DoPovo.Aplicacao.Pacientes.Servicos.Interfaces;
using Clinica.DoPovo.Aplicacao.Transacoes.Interface;
using Clinica.DoPovo.DataTransfer.Pacientes.Request;
using Clinica.DoPovo.DataTransfer.Pacientes.Response;
using Clinica.DoPovo.Dominio.Pacientes.Entidades;
using Clinica.DoPovo.Dominio.Pacientes.Repositorios;
using Clinica.DoPovo.Dominio.Pacientes.Servicos.Comandos;
using Clinica.DoPovo.Dominio.Pacientes.Servicos.Interfaces;
using Clinica.DoPovo.Dominio.Util;
using Clinica.DoPovo.Repositorios.Filtros;

namespace Clinica.DoPovo.Aplicacao.Pacientes.Servicos;

public class PacientesAppServico : IPacientesAppServico
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly IPacientesRepositorio pacientesRepositorio;
    private readonly IPacientesServico pacientesServico;

    public PacientesAppServico(IMapper mapper, IUnitOfWork unitOfWork, IPacientesRepositorio pacientesRepositorio, IPacientesServico pacientesServico)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.pacientesRepositorio = pacientesRepositorio;
        this.pacientesServico = pacientesServico;
    }

    public PacienteResponse Editar(int id, PacienteEditarRequest request)
    {
        var comando = mapper.Map<PacienteEditarComando>(request);

        try
        {
            unitOfWork.BeginTransaction();

            Paciente paciente = pacientesServico.Editar(id, comando);

            unitOfWork.Commit();

            return mapper.Map<PacienteResponse>(paciente);
        }
        catch
        {
            unitOfWork.Rollback();
            throw;
        }
    }

    public void Excluir(int id)
    {
       try
       {
            unitOfWork.BeginTransaction();

            Paciente paciente = pacientesServico.Validar(id);

            pacientesRepositorio.Excluir(paciente);

            unitOfWork.Commit();

        }
       catch
       {
            unitOfWork.Rollback();
            throw;
       }
    }

    public PacienteResponse Inserir(PacienteInserirRequest request)
    {
        var comando = mapper.Map<PacienteInstanciarComando>(request);

        try
        {
            unitOfWork.BeginTransaction();

            Paciente paciente = pacientesServico.Inserir(comando);

            unitOfWork.Commit();

            return mapper.Map<PacienteResponse>(paciente);
        }
        catch
        {
            unitOfWork.Rollback();
            
            throw;
        }
    }

    public PaginacaoConsulta<PacienteResponse> Listar(PacienteListarRequest request)
    {
        PacienteListarFiltro filtro = mapper.Map<PacienteListarFiltro>(request);

        IQueryable<Paciente> query = pacientesRepositorio.Filtrar(filtro);

        PaginacaoConsulta<Paciente> pacientes = pacientesRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

        PaginacaoConsulta<PacienteResponse> response;

        response = mapper.Map<PaginacaoConsulta<PacienteResponse>>(pacientes);

        return response;
    }

    public PacienteResponse Recuperar(int id)
    {
        Paciente paciente = pacientesServico.Validar(id);

        return mapper.Map<PacienteResponse>(paciente);
        
    }
}
