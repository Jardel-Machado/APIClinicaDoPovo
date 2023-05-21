using Clinica.DoPovo.DataTransfer.Pacientes.Request;
using Clinica.DoPovo.DataTransfer.Pacientes.Response;
using Clinica.DoPovo.Dominio.Util;

namespace Clinica.DoPovo.Aplicacao.Pacientes.Servicos.Interfaces;

public interface IPacientesAppServico
{
    PaginacaoConsulta<PacienteResponse> Listar (PacienteListarRequest request);
    PacienteResponse Recuperar(int id);
    PacienteResponse Inserir (PacienteInserirRequest request);
    PacienteResponse Editar (int id, PacienteEditarRequest request);
    void Excluir(int id);
}
