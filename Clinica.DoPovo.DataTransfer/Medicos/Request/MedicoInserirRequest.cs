namespace Clinica.DoPovo.DataTransfer.Medicos.Request;

public class MedicoInserirRequest
{
    public string Nome {get; set;}
    public string Crm {get; set;}
    public IList<int> Especialidades { get; set; }
}
