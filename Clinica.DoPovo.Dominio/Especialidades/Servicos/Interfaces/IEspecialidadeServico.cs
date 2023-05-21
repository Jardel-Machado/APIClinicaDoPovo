using Clinica.DoPovo.Dominio.Especialidades.Entidades;
using Clinica.DoPovo.Dominio.Especialidades.Servicos.Comandos;

namespace Clinica.DoPovo.Dominio.Especialidades.Servicos.Interfaces;

public interface IEspecialidadeServico
{
    Especialidade Validar(int id);
    Especialidade Inserir(EspecialidadeInstanciarComando comando);
    Especialidade Instanciar(EspecialidadeInstanciarComando comando);
    Especialidade Editar(int id, EspecialidadeEditarComando comando);
}
