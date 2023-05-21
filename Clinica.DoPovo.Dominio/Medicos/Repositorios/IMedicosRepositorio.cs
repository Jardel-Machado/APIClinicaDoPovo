using Clinica.DoPovo.Dominio.Genericos;
using Clinica.DoPovo.Dominio.Medicos.Entidades;
using Clinica.DoPovo.Dominio.Medicos.Repositorios.Filtros;

namespace Clinica.DoPovo.Dominio.Medicos.Repositorios;

public interface IMedicosRepositorio : IGenericoRepositorio<Medico>
{
    IQueryable<Medico> Filtrar (MedicoListarFiltro filtro);
}
