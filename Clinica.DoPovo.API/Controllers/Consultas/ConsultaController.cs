using Clinica.DoPovo.Aplicacao.Consultas.Servicos.Interfaces;
using Clinica.DoPovo.DataTransfer.Consultas.Request;
using Clinica.DoPovo.DataTransfer.Consultas.Response;
using Clinica.DoPovo.Dominio.Util;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.DoPovo.API.Controllers.Consultas;

[ApiController]
[Route("api/consultas")]
public class ConsultaController : ControllerBase
{
    private readonly IConsultasAppServico consultasAppServico;

    public ConsultaController(IConsultasAppServico consultasAppServico)
    {
        this.consultasAppServico = consultasAppServico;
    }

    /// <summary>
    /// Recupera uma consulta por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<ConsultaResponse> Recuperar(int id)
    {
        ConsultaResponse response = consultasAppServico.Recuperar(id);

        return Ok(response);
    }

    /// <summary>
    /// Lista as consultas com paginação
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<PaginacaoConsulta<ConsultaResponse>> Listar([FromQuery] ConsultaListarRequest request)
    {
        var response = consultasAppServico.Listar(request);

        return Ok(response);
    }

    /// <summary>
    /// Adiciona uma nova consulta
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<ConsultaResponse> Inserir ([FromBody] ConsultaInserirRequest request)
    {
        ConsultaResponse response = consultasAppServico.Inserir(request);

        return Ok(response);
    }

    /// <summary>
    /// Edita uma consulta por Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public ActionResult<ConsultaResponse> Editar(int id, [FromBody] ConsultaEditarRequest request)
    {
        ConsultaResponse response = consultasAppServico.Editar(id, request);

        return Ok(response);
    }

    /// <summary>
    /// Exclui uma consulta por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult Excluir(int id)
    {
        consultasAppServico.Excluir(id);

        return Ok();
    }     
}
