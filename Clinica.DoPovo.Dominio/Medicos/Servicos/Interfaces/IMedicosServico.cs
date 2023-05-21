using Clinica.DoPovo.Dominio.Medicos.Entidades;
using Clinica.DoPovo.Dominio.Medicos.Servicos.Comandos;

namespace Clinica.DoPovo.Dominio.Medicos.Servicos.Interfaces;

public interface IMedicosServico
{
    Medico Validar(int id);
    Medico Inserir(MedicoInstanciarComando comando, IList<int> especialidades);
    Medico Instanciar(MedicoInstanciarComando comando);
    Medico Editar(int id, MedicoEditarComando comando);
    Medico AdiconarEspecialidade(int id, MedicoAdicionarEspecialidadeComando comando);
    Medico RemoverEspecialidade(int id,  MedicoRemoverEspecialidadeComando comando);
}
