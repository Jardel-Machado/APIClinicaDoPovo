using System.ComponentModel.DataAnnotations;
using Clinica.DoPovo.Dominio.Pacientes.Enumeradores;

namespace Clinica.DoPovo.DataTransfer.Pacientes.Request;

public class PacienteInserirRequest
{
    public string Nome { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]  
    public DateTime DataNascimento { get; set; }
    public ConvenioEnum Convenio { get; set; }
}
