using Clinica.DoPovo.Dominio.Pacientes.Entidades;
using Clinica.DoPovo.Dominio.Pacientes.Repositorios;
using Clinica.DoPovo.Infra.Genericos;
using Clinica.DoPovo.Repositorios.Filtros;
using NHibernate;

namespace Clinica.DoPovo.Infra.Pacientes.Repositorios;

public class PacientesRepositorio : GenericoRepositorio<Paciente>, IPacientesRepositorio
{
    public PacientesRepositorio(ISession session) : base(session)
    {

    }
    public IQueryable<Paciente> Filtrar(PacienteListarFiltro filtro)
    {
        IQueryable<Paciente> query = Query();

        if (!string.IsNullOrWhiteSpace(filtro.Nome))
        {
            query = query.Where(x => x.Nome.Contains(filtro.Nome));
        }

        if (filtro.DataNascimento != DateTime.MinValue)
        {
            query = query.Where(x => x.DataNascimento == filtro.DataNascimento);
        }

        if (filtro.Idade > 0)
        {
            query = query.Where(x => x.Idade == filtro.Idade);
        }

        if (filtro.Convenio.HasValue)
        {
            query = query.Where(x => x.Convenio == filtro.Convenio.Value);
        }

        return query;        

    }
}
