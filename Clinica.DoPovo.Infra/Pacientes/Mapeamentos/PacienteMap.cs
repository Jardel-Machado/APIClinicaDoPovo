using Clinica.DoPovo.Dominio.Pacientes.Entidades;
using Clinica.DoPovo.Dominio.Pacientes.Enumeradores;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Clinica.DoPovo.Infra.Pacientes.Mapeamentos;

public class PacienteMap : ClassMap<Paciente>
{
    public PacienteMap()
    {
        Schema("clinica");
        Table("paciente");
        Id(paciente => paciente.Id).Column("id");
        Map(paciente => paciente.Nome).Column("nome");
        Map(paciente => paciente.DataNascimento).Column("dataNascimento");
        Map(paciente => paciente.Idade).Column("idade");
        Map(paciente => paciente.Convenio).Column("convenio").CustomType<EnumType<ConvenioEnum>>();
    }
}
