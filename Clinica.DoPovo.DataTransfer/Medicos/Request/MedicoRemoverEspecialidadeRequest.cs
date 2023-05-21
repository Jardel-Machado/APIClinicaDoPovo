using Clinica.DoPovo.Dominio.Medicos.Servicos.Comandos;

namespace Clinica.DoPovo.DataTransfer.Medicos.Request;

public class MedicoRemoverEspecialidadeRequest
{
    public int IdMedico { get; set; }
    public MedicoRemoverEspecialidadeComando comando { get; set; }
}
