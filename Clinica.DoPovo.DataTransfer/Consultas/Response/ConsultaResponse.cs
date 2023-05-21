namespace Clinica.DoPovo.DataTransfer.Consultas.Response;

public class ConsultaResponse
{
    public int Id { get; set; }
    public DateTime DataConsulta {get; set;}
    public string NomePaciente {get; set;}
    public string NomeMedico {get; set;}
    public string DescricaoEspecialidade {get; set;}
    
}
