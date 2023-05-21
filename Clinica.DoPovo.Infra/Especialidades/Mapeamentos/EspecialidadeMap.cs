using Clinica.DoPovo.Dominio.Especialidades.Entidades;
using FluentNHibernate.Mapping;

namespace Clinica.DoPovo.Infra.Especialidades.Mapeamentos;

public class EspecialidadeMap : ClassMap<Especialidade>
{
    public EspecialidadeMap()
    {
        Schema("clinica");
        Table("especialidade");
        Id(especialidade => especialidade.Id).Column("id");
        Map(especialidade => especialidade.Descricao).Column("descricao");
    }
}
