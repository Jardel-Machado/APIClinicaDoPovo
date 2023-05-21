using Clinica.DoPovo.Dominio.Medicos.Entidades;
using Clinica.DoPovo.Dominio.Medicos.Repositorios;
using Clinica.DoPovo.Dominio.Medicos.Repositorios.Filtros;
using Clinica.DoPovo.Infra.Genericos;
using NHibernate;

namespace Clinica.DoPovo.Infra.Medicos.Repositorios;

public class MedicosRepositorio : GenericoRepositorio<Medico>, IMedicosRepositorio
{
    public MedicosRepositorio(ISession session) : base(session)
    {
        
    }

    public IQueryable<Medico> Filtrar(MedicoListarFiltro filtro)
    {
        IQueryable<Medico> query = Query();

        if (!string.IsNullOrWhiteSpace(filtro.Nome))
        {
            query = query.Where(p => p.Nome.Contains(filtro.Nome));
        }

        if (!string.IsNullOrWhiteSpace(filtro.Crm))
        {
            query = query.Where(p => p.Crm.Contains(filtro.Crm));
        }

        if (filtro.IdEspecialidades != 0)
        {
            query = query.Where(p => p.Equals(filtro.IdEspecialidades));
        }

        return query;
    }
}
