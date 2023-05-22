using Clinica.DoPovo.Dominio.Consultas.Entidades;
using Clinica.DoPovo.Dominio.Consultas.Repositorios;
using Clinica.DoPovo.Dominio.Consultas.Servicos.Comandos;
using Clinica.DoPovo.Dominio.Consultas.Servicos.Interfaces;
using Clinica.DoPovo.Dominio.Especialidades.Entidades;
using Clinica.DoPovo.Dominio.Especialidades.Servicos.Interfaces;
using Clinica.DoPovo.Dominio.Medicos.Entidades;
using Clinica.DoPovo.Dominio.Medicos.Servicos.Interfaces;
using Clinica.DoPovo.Dominio.Pacientes.Entidades;
using Clinica.DoPovo.Dominio.Pacientes.Servicos.Interfaces;

namespace Clinica.DoPovo.Dominio.Consultas.Servicos;

public class ConsultaServico : IConsultaServico
{
    private readonly IConsultasRepositorio consultasRepositorio;
    private readonly IPacientesServico pacientesServico;
    private readonly IMedicosServico medicosServico;
    private readonly IEspecialidadeServico especialidadeServico;

    public ConsultaServico(IConsultasRepositorio consultasRepositorio, IPacientesServico pacientesServico, IMedicosServico medicosServico, IEspecialidadeServico especialidadeServico)
    {
        this.consultasRepositorio = consultasRepositorio;
        this.pacientesServico = pacientesServico;
        this.medicosServico = medicosServico;
        this.especialidadeServico = especialidadeServico;
    }

    public Consulta Editar(int id, ConsultaEditarComando comando)
    {
        Consulta consulta = Validar(id);

        Paciente paciente = pacientesServico.Validar(comando.IdPaciente);

        consulta.SetPaciente(paciente);

        Medico medico = medicosServico.Validar(comando.IdMedico);

        consulta.SetMedico(medico);

        Especialidade especialidade = especialidadeServico.Validar(comando.IdEspecialidade);

        consulta.SetEspecialidade(especialidade);

        consulta.SetDataConsulta(comando.DataConsulta);

        return consultasRepositorio.Editar(consulta);        
    }

    public Consulta Inserir(ConsultaInstanciarComando comando)
    {
        Consulta consulta = Instanciar(comando);

        return consultasRepositorio.Inserir(consulta);
    }

    public Consulta Instanciar(ConsultaInstanciarComando comando)
    {
        Paciente paciente = pacientesServico.Validar(comando.IdPaciente);

        Medico medico = medicosServico.Validar(comando.IdMedico);

        Especialidade especialidade = especialidadeServico.Validar(comando.IdEspecialidade);

        medicosServico.VerificarEspecialidadeExistenteNoMedico(medico, especialidade);

        return new Consulta(paciente, medico, especialidade, comando.DataConsulta);
    }

    public Consulta Validar(int id)
    {
        Consulta consulta = consultasRepositorio.Recuperar(id);

        if (consulta == null)
        {
            throw new ArgumentException("Consulta não encontrada!");
        }

        return consulta;
    }
}
