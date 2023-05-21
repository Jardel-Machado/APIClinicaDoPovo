using Clinica.DoPovo.DataTransfer.Consultas.Request;
using Clinica.DoPovo.DataTransfer.Consultas.Response;
using Clinica.DoPovo.Dominio.Util;

namespace Clinica.DoPovo.Aplicacao.Consultas.Servicos.Interfaces;

public interface IConsultasAppServico
{
    PaginacaoConsulta<ConsultaResponse> Listar (ConsultaListarRequest request);
    ConsultaResponse Recuperar(int id);
    ConsultaResponse Inserir (ConsultaInserirRequest request);
    ConsultaResponse Editar (int id, ConsultaEditarRequest request);
    void Excluir(int id);
}
