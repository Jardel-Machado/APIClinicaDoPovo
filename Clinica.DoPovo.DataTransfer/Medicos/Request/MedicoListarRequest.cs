using Clinica.DoPovo.Dominio.Util.Enumeradores;
using Dominio.Util;

namespace Clinica.DoPovo.DataTransfer.Medicos.Request;

public class MedicoListarRequest : PaginacaoFiltro
{
    public MedicoListarRequest() : base(cpOrd:"Nome", tpOrd: TipoOrdenacaoEnum.Asc)
    {
    }

    public string Nome {get; set;}
    public string Crm {get; set;}
    public IList<int> Especialidades { get; set; }
}
