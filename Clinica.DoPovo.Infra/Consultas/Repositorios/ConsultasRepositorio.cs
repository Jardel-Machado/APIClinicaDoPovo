using Clinica.DoPovo.Dominio.Consultas.Entidades;
using Clinica.DoPovo.Dominio.Consultas.Repositorios;
using Clinica.DoPovo.Dominio.Consultas.Repositorios.Filtros;
using Clinica.DoPovo.Infra.Genericos;
using NHibernate;

namespace Clinica.DoPovo.Infra.Consultas.Repositorios;

public class ConsultasRepositorio : GenericoRepositorio<Consulta>, IConsultasRepositorio
{
    public ConsultasRepositorio(ISession session) : base(session)
    {
        
    }

    public IQueryable<Consulta> Filtrar(ConsultaListarFiltro filtro)
    {
        IQueryable<Consulta> query = Query();

        if (!string.IsNullOrWhiteSpace(filtro.NomePaciente))
        {
            query = query.Where(p => p.Paciente.Nome.Contains(filtro.NomePaciente));
        }

        if (!string.IsNullOrWhiteSpace(filtro.NomeMedico))
        {
            query = query.Where(p => p.Medico.Nome.Contains(filtro.NomeMedico));
        }

        if (!string.IsNullOrWhiteSpace(filtro.DescricaoEspecialidade))
        {
            query = query.Where(p => p.Especialidade.Descricao.Contains(filtro.DescricaoEspecialidade));
        }

        if (filtro.DataConsulta != DateTime.MinValue)
        {
            query = query.Where(x => x.DataConsulta == filtro.DataConsulta);
        }

        return query;
    }
}
