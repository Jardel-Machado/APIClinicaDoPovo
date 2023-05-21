using Clinica.DoPovo.Aplicacao.Pacientes.Servicos.Interfaces;
using Clinica.DoPovo.DataTransfer.Pacientes.Request;
using Clinica.DoPovo.DataTransfer.Pacientes.Response;
using Clinica.DoPovo.Dominio.Util;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.DoPovo.API.Controllers.Pacientes;

[ApiController]
[Route("api/pacientes")]

public class PacienteController : ControllerBase
{
    private readonly IPacientesAppServico pacientesAppServico;

    public PacienteController(IPacientesAppServico pacientesAppServico)
    {
        this.pacientesAppServico = pacientesAppServico;
    }

    /// <summary>
    /// Recupera um paciente por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<PacienteResponse> Recuperar(int id)
    {
        PacienteResponse response = pacientesAppServico.Recuperar(id);

        return Ok(response);
    }

    /// <summary>
    /// Lista os pacientes com paginação
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<PaginacaoConsulta<PacienteResponse>> Listar([FromQuery] PacienteListarRequest request)
    {
        var response = pacientesAppServico.Listar(request);

        return Ok(response);
    }

    /// <summary>
    /// Adiciona um novo paciente 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<PacienteResponse> Inserir ([FromBody] PacienteInserirRequest request)
    {
        PacienteResponse response = pacientesAppServico.Inserir(request);

        return Ok(response);
    }

    /// <summary>
    /// Edita um paciente por Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public ActionResult<PacienteResponse> Editar(int id, [FromBody] PacienteEditarRequest request)
    {
        PacienteResponse response = pacientesAppServico.Editar(id, request);

        return Ok(response);
    }

    /// <summary>
    /// Exclui um paciente por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult Excluir(int id)
    {
        pacientesAppServico.Excluir(id);

        return Ok();
    }     
}
