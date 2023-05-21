using Clinica.DoPovo.Dominio.Consultas.Entidades;
using FluentNHibernate.Mapping;

namespace Clinica.DoPovo.Infra.Consultas.Mapeamentos;

public class ConsultaMap : ClassMap<Consulta>
{
    public ConsultaMap()
    {
        Schema("clinica");
        Table("consulta");
        Id(consulta => consulta.Id).Column("id");
        Map(consulta => consulta.DataConsulta).Column("dataConsulta");
        References(consulta => consulta.Paciente).Column("idPaciente");
        References(consulta => consulta.Medico).Column("idMedico");
        References(consulta => consulta.Especialidade).Column("idEspecialidade");        
    }
}
