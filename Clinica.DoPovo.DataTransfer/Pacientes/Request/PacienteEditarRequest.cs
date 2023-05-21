using Clinica.DoPovo.Dominio.Pacientes.Enumeradores;

namespace Clinica.DoPovo.DataTransfer.Pacientes.Request;

public class PacienteEditarRequest
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public ConvenioEnum Convenio { get; set; }
}
