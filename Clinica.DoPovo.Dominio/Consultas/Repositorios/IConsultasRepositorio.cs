using Clinica.DoPovo.Dominio.Consultas.Entidades;
using Clinica.DoPovo.Dominio.Consultas.Repositorios.Filtros;
using Clinica.DoPovo.Dominio.Genericos;

namespace Clinica.DoPovo.Dominio.Consultas.Repositorios;

public interface IConsultasRepositorio : IGenericoRepositorio<Consulta>
{
    IQueryable<Consulta> Filtrar (ConsultaListarFiltro filtro);
}
