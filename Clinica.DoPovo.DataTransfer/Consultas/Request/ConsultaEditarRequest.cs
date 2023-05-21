using System.ComponentModel.DataAnnotations;

namespace Clinica.DoPovo.DataTransfer.Consultas.Request;

public class ConsultaEditarRequest
{
    public int IdPaciente {get; set;}
    public int IdMedico {get; set;}
    public int IdEspecialidade {get; set;}

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
    public DateTime DataConsulta {get; set;}
}
