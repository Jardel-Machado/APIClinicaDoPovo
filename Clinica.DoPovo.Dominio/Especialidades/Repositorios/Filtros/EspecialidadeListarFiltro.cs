using Clinica.DoPovo.Dominio.Util.Enumeradores;
using Dominio.Util;

namespace Clinica.DoPovo.Dominio.Especialidades.Repositorios.Filtros;

public class EspecialidadeListarFiltro : PaginacaoFiltro
{    
    public string Descricao { get; set; }

    public EspecialidadeListarFiltro() : base(cpOrd:"Descricao", tpOrd:TipoOrdenacaoEnum.Asc)
    {
        
    }
}
