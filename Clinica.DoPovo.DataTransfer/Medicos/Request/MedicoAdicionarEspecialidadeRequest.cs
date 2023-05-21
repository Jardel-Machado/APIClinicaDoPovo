using Clinica.DoPovo.Dominio.Medicos.Servicos.Comandos;

namespace Clinica.DoPovo.DataTransfer.Medicos.Request;

public class MedicoAdicionarEspecialidadeRequest
{
    public int IdMedico { get; set; }
    public MedicoAdicionarEspecialidadeComando comando { get; set; }
}
