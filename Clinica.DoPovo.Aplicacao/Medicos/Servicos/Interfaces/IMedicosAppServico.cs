using Clinica.DoPovo.DataTransfer.Medicos.Request;
using Clinica.DoPovo.DataTransfer.Medicos.Response;
using Clinica.DoPovo.Dominio.Util;

namespace Clinica.DoPovo.Aplicacao.Medicos.Servicos.Interfaces;

public interface IMedicosAppServico
{
    PaginacaoConsulta<MedicoResponse> Listar(MedicoListarRequest request);

    MedicoResponse Recuperar (int id);

    MedicoResponse Inserir (MedicoInserirRequest request);

    MedicoResponse Editar (int id, MedicoEditarRequest request);

    MedicoResponse AdicionarEspecialidade (MedicoAdicionarEspecialidadeRequest request);

    MedicoResponse RemoverEspecialidade (MedicoRemoverEspecialidadeRequest request);

    void Excluir (int id);
}
