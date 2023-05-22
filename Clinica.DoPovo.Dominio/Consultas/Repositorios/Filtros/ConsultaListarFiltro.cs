using Clinica.DoPovo.Dominio.Util.Enumeradores;
using Dominio.Util;

namespace Clinica.DoPovo.Dominio.Consultas.Repositorios.Filtros;

public class ConsultaListarFiltro : PaginacaoFiltro
{
    public string NomePaciente {get; set;}
    public string NomeMedico {get; set;}
    public string DescricaoEspecialidade {get; set;}
    public DateTime DataConsulta {get; set;}
    public ConsultaListarFiltro() : base(cpOrd:"DataConsulta", tpOrd:TipoOrdenacaoEnum.Asc)
    {

    }
}
