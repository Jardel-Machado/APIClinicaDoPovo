using Clinica.DoPovo.Dominio.Util.Enumeradores;
using Dominio.Util;

namespace Clinica.DoPovo.DataTransfer.Especialidades.Request;

public class EspecialidadeListarRequest : PaginacaoFiltro
{
    public string Descricao { get; set; }

    public EspecialidadeListarRequest() : base(cpOrd:"Descricao", tpOrd:TipoOrdenacaoEnum.Asc)
    {
        
    }
}
