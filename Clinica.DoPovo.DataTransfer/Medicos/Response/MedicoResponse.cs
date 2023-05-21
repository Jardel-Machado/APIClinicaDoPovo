using Clinica.DoPovo.DataTransfer.Especialidades.Response;

namespace Clinica.DoPovo.DataTransfer.Medicos.Response;

public class MedicoResponse
{
    public int Id { get; set; }
    public string Nome {get; set;}
    public string Crm {get; set;}
    public IList<EspecialidadeResponse> Especialidades { get; set; }
}
