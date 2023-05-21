using Clinica.DoPovo.Dominio.Genericos;
using Clinica.DoPovo.Dominio.Pacientes.Entidades;
using Clinica.DoPovo.Repositorios.Filtros;


namespace Clinica.DoPovo.Dominio.Pacientes.Repositorios;

public interface IPacientesRepositorio : IGenericoRepositorio<Paciente>
{
    IQueryable<Paciente> Filtrar (PacienteListarFiltro filtro);
}
