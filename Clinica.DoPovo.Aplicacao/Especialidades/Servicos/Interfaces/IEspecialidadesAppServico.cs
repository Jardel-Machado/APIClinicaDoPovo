using Clinica.DoPovo.DataTransfer.Especialidades.Request;
using Clinica.DoPovo.DataTransfer.Especialidades.Response;
using Clinica.DoPovo.Dominio.Util;

namespace Clinica.DoPovo.Aplicacao.Especialidades.Servicos.Interfaces;

public interface IEspecialidadesAppServico
{
    PaginacaoConsulta<EspecialidadeResponse> Listar (EspecialidadeListarRequest request);
    EspecialidadeResponse Recuperar(int id);
    EspecialidadeResponse Inserir (EspecialidadeInserirRequest request);
    EspecialidadeResponse Editar (int id, EspecialidadeEditarRequest request);
    void Excluir(int id);
}
