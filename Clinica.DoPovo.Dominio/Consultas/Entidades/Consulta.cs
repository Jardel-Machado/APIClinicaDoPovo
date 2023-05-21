using Clinica.DoPovo.Dominio.Especialidades.Entidades;
using Clinica.DoPovo.Dominio.Medicos.Entidades;
using Clinica.DoPovo.Dominio.Pacientes.Entidades;

namespace Clinica.DoPovo.Dominio.Consultas.Entidades;

public class Consulta
{
    public virtual int Id {get; protected set;}
    public virtual Paciente Paciente {get; protected set;}
    public virtual Medico Medico {get; protected set;}
    public virtual Especialidade Especialidade {get; protected set;}
    public virtual DateTime DataConsulta {get; protected set;}

    protected Consulta()
    {
        
    }

    public Consulta(Paciente paciente, Medico medico, Especialidade especialidade, DateTime dataConsulta)
    {
        SetPaciente(paciente);
        SetMedico(medico);
        SetEspecialidade(especialidade);
        SetDataConsulta(dataConsulta);
    }

    public virtual void SetPaciente(Paciente paciente)
    {
        if (paciente is null)
        {
            throw new ArgumentException("Id do paciente é inválido!");
        }

        Paciente = paciente;
    }

    public virtual void SetMedico(Medico medico)
    {
        if (medico is null)
        {
            throw new ArgumentException("Id do medico é inválido!");
        }

        Medico = medico;
    }

    public virtual void SetEspecialidade(Especialidade especialidade)
    {
        if (especialidade is null)
        {
            throw new ArgumentException("Id da especialidade é inválido!");
        }

        if (Medico != null && !Medico.PossuiEspecialidade(especialidade))
        {
            throw new ArgumentException("O médico não possui essa especialidade.");
        }

        Especialidade = especialidade;
    }

    public virtual void SetDataConsulta(DateTime dataConsulta)
    {
        if (dataConsulta < DateTime.Now || dataConsulta == DateTime.MinValue)
        {
            throw new ArgumentException("Data da consulta inválida!");
        }

        if (dataConsulta.DayOfWeek == DayOfWeek.Saturday || dataConsulta.DayOfWeek == DayOfWeek.Sunday)
        {
            throw new ArgumentException("Não é possível agendar uma consulta para o sábado ou domingo!");
        }

        DataConsulta = dataConsulta;
    }
}
