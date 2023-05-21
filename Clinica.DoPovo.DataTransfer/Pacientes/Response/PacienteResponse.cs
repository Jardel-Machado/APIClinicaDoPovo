using Clinica.DoPovo.Dominio.Pacientes.Enumeradores;

namespace Clinica.DoPovo.DataTransfer.Pacientes.Response;

public class PacienteResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public int Idade { get; set; }
    public ConvenioEnum Convenio { get; set; }
}
