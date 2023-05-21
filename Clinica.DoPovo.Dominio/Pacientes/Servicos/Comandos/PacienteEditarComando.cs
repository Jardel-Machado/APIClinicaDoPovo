using Clinica.DoPovo.Dominio.Pacientes.Enumeradores;

namespace Clinica.DoPovo.Dominio.Pacientes.Servicos.Comandos;

public class PacienteEditarComando
{
    public string Nome { get; set; }

    public DateTime DataNascimento { get; set; }    

    public ConvenioEnum Convenio { get; set; }
}
