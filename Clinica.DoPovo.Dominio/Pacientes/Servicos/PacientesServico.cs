using Clinica.DoPovo.Dominio.Pacientes.Entidades;
using Clinica.DoPovo.Dominio.Pacientes.Repositorios;
using Clinica.DoPovo.Dominio.Pacientes.Servicos.Comandos;
using Clinica.DoPovo.Dominio.Pacientes.Servicos.Interfaces;

namespace Clinica.DoPovo.Dominio.Pacientes.Servicos;

public class PacientesServico : IPacientesServico
{
    private readonly IPacientesRepositorio pacientesRepositorio;

    public PacientesServico(IPacientesRepositorio pacientesRepositorio)
    {
        this.pacientesRepositorio = pacientesRepositorio;
    }

    public Paciente Editar(int id, PacienteEditarComando comando)
    {
        Paciente paciente = Validar(id);

        paciente.SetNome(comando.Nome);

        paciente.SetDataNacimento(comando.DataNascimento);

        paciente.SetConvenio(comando.Convenio);

        return pacientesRepositorio.Editar(paciente);        
    }

    public Paciente Inserir(PacienteInstanciarComando comando)
    {
        Paciente paciente = Instanciar(comando);

        return pacientesRepositorio.Inserir(paciente);
    }

    public Paciente Instanciar(PacienteInstanciarComando comando)
    {
        return new Paciente(comando.Nome, comando.DataNascimento, comando.Convenio);
    }

    public Paciente Validar(int id)
    {
        Paciente paciente = pacientesRepositorio.Recuperar(id);

        if (paciente == null)
        {
            throw new ArgumentException("Paciente não encontrado!");
        }

        return paciente;
    }
}
