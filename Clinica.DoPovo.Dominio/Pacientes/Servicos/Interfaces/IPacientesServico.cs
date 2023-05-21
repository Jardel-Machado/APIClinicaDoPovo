using Clinica.DoPovo.Dominio.Pacientes.Entidades;
using Clinica.DoPovo.Dominio.Pacientes.Servicos.Comandos;

namespace Clinica.DoPovo.Dominio.Pacientes.Servicos.Interfaces;

public interface IPacientesServico
{
    Paciente Validar(int id);
    Paciente Inserir(PacienteInstanciarComando comando);
    Paciente Instanciar(PacienteInstanciarComando comando);
    Paciente Editar(int id, PacienteEditarComando comando);
}
