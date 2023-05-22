using Clinica.DoPovo.Dominio.Util.Enumeradores;
using Dominio.Util;

namespace Clinica.DoPovo.Dominio.Medicos.Repositorios.Filtros;

public class MedicoListarFiltro : PaginacaoFiltro
{
    public string Nome {get; set;}
    public string Crm {get; set;}
    public int IdEspecialidades { get; set; }
    public MedicoListarFiltro() : base(cpOrd:"Nome", tpOrd: TipoOrdenacaoEnum.Asc)
    {
        
    }
}
