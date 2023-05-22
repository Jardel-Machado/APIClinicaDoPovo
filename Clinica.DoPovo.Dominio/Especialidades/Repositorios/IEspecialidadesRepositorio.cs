using Clinica.DoPovo.Dominio.Especialidades.Entidades;
using Clinica.DoPovo.Dominio.Especialidades.Repositorios.Filtros;
using Clinica.DoPovo.Dominio.Genericos;


namespace Clinica.DoPovo.Dominio.Especialidades.Repositorios;

public interface IEspecialidadesRepositorio : IGenericoRepositorio<Especialidade>
{
    IQueryable<Especialidade> Filtrar (EspecialidadeListarFiltro filtro);
}
