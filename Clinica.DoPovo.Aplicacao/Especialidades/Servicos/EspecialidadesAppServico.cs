using AutoMapper;
using Clinica.DoPovo.Aplicacao.Especialidades.Servicos.Interfaces;
using Clinica.DoPovo.Aplicacao.Transacoes.Interface;
using Clinica.DoPovo.DataTransfer.Especialidades.Request;
using Clinica.DoPovo.DataTransfer.Especialidades.Response;
using Clinica.DoPovo.Dominio.Especialidades.Entidades;
using Clinica.DoPovo.Dominio.Especialidades.Repositorios;
using Clinica.DoPovo.Dominio.Especialidades.Repositorios.Filtros;
using Clinica.DoPovo.Dominio.Especialidades.Servicos.Comandos;
using Clinica.DoPovo.Dominio.Especialidades.Servicos.Interfaces;
using Clinica.DoPovo.Dominio.Util;


namespace Clinica.DoPovo.Aplicacao.Especialidades.Servicos;

public class EspecialidadesAppServico : IEspecialidadesAppServico
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly IEspecialidadesRepositorio especialidadesRepositorio;
    private readonly IEspecialidadeServico especialidadeServico;

    public EspecialidadesAppServico(IMapper mapper, IUnitOfWork unitOfWork, IEspecialidadesRepositorio especialidadesRepositorio, IEspecialidadeServico especialidadeServico)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.especialidadesRepositorio = especialidadesRepositorio;
        this.especialidadeServico = especialidadeServico;
    }

    public EspecialidadeResponse Editar(int id, EspecialidadeEditarRequest request)
    {
        var comando = mapper.Map<EspecialidadeEditarComando>(request);

        try
        {
            unitOfWork.BeginTransaction();

            Especialidade especialidade = especialidadeServico.Editar(id, comando);

            unitOfWork.Commit();

            return mapper.Map<EspecialidadeResponse>(especialidade);
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

            Especialidade especialidade = especialidadeServico.Validar(id);

            especialidadesRepositorio.Excluir(especialidade);

            unitOfWork.Commit();

        }
       catch
       {
            unitOfWork.Rollback();
            throw;
       }
    }

    public EspecialidadeResponse Inserir(EspecialidadeInserirRequest request)
    {
        var comando = mapper.Map<EspecialidadeInstanciarComando>(request);

        try
        {
            unitOfWork.BeginTransaction();

            Especialidade especialidade = especialidadeServico.Inserir(comando);

            unitOfWork.Commit();

            return mapper.Map<EspecialidadeResponse>(especialidade);
        }
        catch
        {
            unitOfWork.Rollback();
            throw;
        }
    }

    public PaginacaoConsulta<EspecialidadeResponse> Listar(EspecialidadeListarRequest request)
    {
        EspecialidadeListarFiltro filtro = mapper.Map<EspecialidadeListarFiltro>(request);

        IQueryable<Especialidade> query = especialidadesRepositorio.Filtrar(filtro);

        PaginacaoConsulta<Especialidade> especialidades = especialidadesRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

        PaginacaoConsulta<EspecialidadeResponse> response;

        response = mapper.Map<PaginacaoConsulta<EspecialidadeResponse>>(especialidades);

        return response;
    }

    public EspecialidadeResponse Recuperar(int id)
    {
        Especialidade especialidade = especialidadeServico.Validar(id);

        return mapper.Map<EspecialidadeResponse>(especialidade);
    }
}
