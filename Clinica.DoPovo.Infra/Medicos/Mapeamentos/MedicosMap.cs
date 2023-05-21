using Clinica.DoPovo.Dominio.Medicos.Entidades;
using FluentNHibernate.Mapping;

namespace Clinica.DoPovo.Infra.Medicos.Mapeamentos;

public class MedicosMap : ClassMap<Medico>
{
    public MedicosMap()
    {
        Schema("clinica");
        Table("medico");
        Id(medico => medico.Id).Column("id");
        Map(medico => medico.Nome).Column("nome");
        Map(medico => medico.Crm).Column("crm");
        HasManyToMany(medico => medico.Especialidades)
        .Table("medicoEspecialidade")
        .ParentKeyColumn("idMedico")
        .ChildKeyColumn("idEspecialidade")
        .Cascade.SaveUpdate();
    }
}
