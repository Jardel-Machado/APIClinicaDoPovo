using Clinica.DoPovo.Dominio.Pacientes.Enumeradores;
using Clinica.DoPovo.Dominio.Util.Enumeradores;
using Dominio.Util;

namespace Clinica.DoPovo.DataTransfer.Pacientes.Request;

public class PacienteListarRequest : PaginacaoFiltro
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public int Idade { get; set; }
    public ConvenioEnum? Convenio { get; set; }
    public PacienteListarRequest() : base(cpOrd:"Nome", tpOrd:TipoOrdenacaoEnum.Asc)
    {
        
    }
}
