using AutoMapper;
using Clinica.DoPovo.Aplicacao.Medicos.Servicos.Interfaces;
using Clinica.DoPovo.Aplicacao.Transacoes.Interface;
using Clinica.DoPovo.DataTransfer.Medicos.Request;
using Clinica.DoPovo.DataTransfer.Medicos.Response;
using Clinica.DoPovo.Dominio.Medicos.Entidades;
using Clinica.DoPovo.Dominio.Medicos.Repositorios;
using Clinica.DoPovo.Dominio.Medicos.Repositorios.Filtros;
using Clinica.DoPovo.Dominio.Medicos.Servicos.Comandos;
using Clinica.DoPovo.Dominio.Medicos.Servicos.Interfaces;
using Clinica.DoPovo.Dominio.Util;

namespace Clinica.DoPovo.Aplicacao.Medicos.Servicos;

public class MedicosAppServico : IMedicosAppServico
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMedicosServico medicosServico;
    private readonly IMedicosRepositorio medicosRepositorio;

    public MedicosAppServico(IMapper mapper, IUnitOfWork unitOfWork, IMedicosServico medicosServico, IMedicosRepositorio medicosRepositorio)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.medicosServico = medicosServico;
        this.medicosRepositorio = medicosRepositorio;
    }

    public MedicoResponse AdicionarEspecialidade(MedicoAdicionarEspecialidadeRequest request)
    {
        try
        {
            unitOfWork.BeginTransaction();

            Medico medico = medicosServico.AdiconarEspecialidade(request.IdMedico, request.comando);

            medicosRepositorio.Editar(medico);

            MedicoResponse response = mapper.Map<MedicoResponse>(medico);

            unitOfWork.Commit();

            return response;
        }
        catch
        {
            unitOfWork.Rollback();
            
            throw;
        }
    }

    public MedicoResponse Editar(int id, MedicoEditarRequest request)
    {
        var comando = mapper.Map<MedicoEditarComando>(request);

        try
        {
            unitOfWork.BeginTransaction();

            Medico medico = medicosServico.Validar(id);

            medico = medicosServico.Editar(id, comando);

            unitOfWork.Commit();

            return mapper.Map<MedicoResponse>(medico);
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

            Medico medico = medicosServico.Validar(id);

            medicosRepositorio.Excluir(medico);

            unitOfWork.Commit();

        }
        catch
        {
            unitOfWork.Rollback();

            throw;
        }
    }

    public MedicoResponse Inserir(MedicoInserirRequest request)
    {
       var comando = mapper.Map<MedicoInstanciarComando>(request);

       try
       {
            unitOfWork.BeginTransaction();

            Medico medico = medicosServico.Inserir(comando, request.Especialidades);

            unitOfWork.Commit();

            return mapper.Map<MedicoResponse>(medico);
        }
        catch 
        {
            unitOfWork.Rollback();

            throw;
        }
    }

    public PaginacaoConsulta<MedicoResponse> Listar(MedicoListarRequest request)
    {
        MedicoListarFiltro filtro = mapper.Map<MedicoListarFiltro>(request);

        IQueryable<Medico> query = medicosRepositorio.Filtrar(filtro);

        PaginacaoConsulta<Medico> medicos = medicosRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

        PaginacaoConsulta<MedicoResponse> response;

        response = mapper.Map<PaginacaoConsulta<MedicoResponse>>(medicos);

        return response;
    }

    public MedicoResponse Recuperar(int id)
    {
        Medico medico = medicosServico.Validar(id);

        MedicoResponse response = mapper.Map<MedicoResponse>(medico);

        return response;
    }

    public MedicoResponse RemoverEspecialidade(MedicoRemoverEspecialidadeRequest request)
    {
        try
        {
            unitOfWork.BeginTransaction();

            Medico medico = medicosServico.RemoverEspecialidade(request.IdMedico, request.comando);

            medicosRepositorio.Editar(medico);

            MedicoResponse response = mapper.Map<MedicoResponse>(medico);

            unitOfWork.Commit();

            return response;
        }
        catch
        {
            unitOfWork.Rollback();
            
            throw;
        }
    }
}
