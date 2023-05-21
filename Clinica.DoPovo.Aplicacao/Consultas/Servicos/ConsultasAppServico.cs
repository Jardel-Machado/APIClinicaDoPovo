using AutoMapper;
using Clinica.DoPovo.Aplicacao.Consultas.Servicos.Interfaces;
using Clinica.DoPovo.Aplicacao.Transacoes.Interface;
using Clinica.DoPovo.DataTransfer.Consultas.Request;
using Clinica.DoPovo.DataTransfer.Consultas.Response;
using Clinica.DoPovo.Dominio.Consultas.Entidades;
using Clinica.DoPovo.Dominio.Consultas.Repositorios;
using Clinica.DoPovo.Dominio.Consultas.Repositorios.Filtros;
using Clinica.DoPovo.Dominio.Consultas.Servicos.Comandos;
using Clinica.DoPovo.Dominio.Consultas.Servicos.Interfaces;
using Clinica.DoPovo.Dominio.Util;

namespace Clinica.DoPovo.Aplicacao.Consultas.Servicos;

public class ConsultasAppServico : IConsultasAppServico
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly IConsultasRepositorio consultasRepositorio;
    private readonly IConsultaServico consultaServico;

    public ConsultasAppServico(IMapper mapper, IUnitOfWork unitOfWork, IConsultasRepositorio consultasRepositorio, IConsultaServico consultaServico)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.consultasRepositorio = consultasRepositorio;
        this.consultaServico = consultaServico;
    }

    public ConsultaResponse Editar(int id, ConsultaEditarRequest request)
    {
        var comando = mapper.Map<ConsultaEditarComando>(request);

        try
        {
            unitOfWork.BeginTransaction();  
            
            Consulta consulta = consultaServico.Validar(id);           
            
            consulta = consultaServico.Editar(id, comando);

            unitOfWork.Commit();

            return mapper.Map<ConsultaResponse>(consulta);
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

            Consulta consulta = consultaServico.Validar(id);

            consultasRepositorio.Excluir(consulta);

            unitOfWork.Commit();
        }
        catch
        {
            unitOfWork.Rollback();

            throw;
        }
    }

    public ConsultaResponse Inserir(ConsultaInserirRequest request)
    {
        var comando = mapper.Map<ConsultaInstanciarComando>(request);
        
        try
        {
            unitOfWork.BeginTransaction();

            Consulta consulta = consultaServico.Inserir(comando);

            unitOfWork.Commit();

            return mapper.Map<ConsultaResponse>(consulta);
        }
        catch
        {
            unitOfWork.Rollback();
            throw;
        }
    }

    public PaginacaoConsulta<ConsultaResponse> Listar(ConsultaListarRequest request)
    {
        ConsultaListarFiltro filtro = mapper.Map<ConsultaListarFiltro>(request);

        IQueryable<Consulta> query = consultasRepositorio.Filtrar(filtro);

        PaginacaoConsulta<Consulta> consultas = consultasRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

        PaginacaoConsulta<ConsultaResponse> response;

        response = mapper.Map<PaginacaoConsulta<ConsultaResponse>>(consultas);

        return response;
    }

    public ConsultaResponse Recuperar(int id)
    {
        Consulta consulta = consultaServico.Validar(id);

        var response = mapper.Map<ConsultaResponse>(consulta);
        
        return response;
    }
}
