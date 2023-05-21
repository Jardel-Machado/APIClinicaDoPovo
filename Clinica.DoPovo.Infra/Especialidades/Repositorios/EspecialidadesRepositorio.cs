using Clinica.DoPovo.Dominio.Especialidades.Entidades;
using Clinica.DoPovo.Dominio.Especialidades.Repositorios;
using Clinica.DoPovo.Dominio.Especialidades.Repositorios.Filtros;
using Clinica.DoPovo.Infra.Genericos;
using NHibernate;

namespace Clinica.DoPovo.Infra.Especialidades.Repositorios;

public class EspecialidadesRepositorio : GenericoRepositorio<Especialidade>, IEspecialidadesRepositorio
{
    public EspecialidadesRepositorio(ISession session) : base(session)
    {

    }

    public IQueryable<Especialidade> Filtrar(EspecialidadeListarFiltro filtro)
    {
        IQueryable<Especialidade> query = Query();

        if (!string.IsNullOrWhiteSpace(filtro.Descricao))
        {
            query = query.Where(x => x.Descricao.Contains(filtro.Descricao));
        }

        return query;
    }
}
