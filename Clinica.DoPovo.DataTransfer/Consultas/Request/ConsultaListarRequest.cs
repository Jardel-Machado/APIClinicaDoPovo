using Clinica.DoPovo.Dominio.Util.Enumeradores;
using Dominio.Util;

namespace Clinica.DoPovo.DataTransfer.Consultas.Request;

public class ConsultaListarRequest : PaginacaoFiltro
{
    public DateTime DataConsulta {get; set;}
    public string NomePaciente {get; set;}
    public string NomeMedico {get; set;}
    public string DescricaoEspecialidade {get; set;}
    
    public ConsultaListarRequest() : base(cpOrd:"DataConsulta", tpOrd: TipoOrdenacaoEnum.Asc)
    {

    }
}
