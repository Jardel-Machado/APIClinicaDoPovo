using Clinica.DoPovo.Aplicacao.Especialidades.Servicos.Interfaces;
using Clinica.DoPovo.DataTransfer.Especialidades.Request;
using Clinica.DoPovo.DataTransfer.Especialidades.Response;
using Clinica.DoPovo.Dominio.Util;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.DoPovo.API.Controllers.Especialidades;

[ApiController]
[Route("api/especialidades")]

public class EspecialidadeController : ControllerBase
{
    private readonly IEspecialidadesAppServico especialidadesAppServico;

    public EspecialidadeController(IEspecialidadesAppServico especialidadesAppServico)
    {
        this.especialidadesAppServico = especialidadesAppServico;
    }

    /// <summary>
    /// Recupera uma especialidade por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<EspecialidadeResponse> Recuperar(int id)
    {
        EspecialidadeResponse response = especialidadesAppServico.Recuperar(id);

        return Ok(response);
    }

    /// <summary>
    /// Lista as especialidades com paginação
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<PaginacaoConsulta<EspecialidadeResponse>> Listar([FromQuery] EspecialidadeListarRequest request)
    {
        var response = especialidadesAppServico.Listar(request);

        return Ok(response);
    }

    /// <summary>
    /// Adiciona uma nova especialidade
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<EspecialidadeResponse> Inserir ([FromBody] EspecialidadeInserirRequest request)
    {
        EspecialidadeResponse response = especialidadesAppServico.Inserir(request);

        return Ok(response);
    }

    /// <summary>
    /// Edita uma especialidade por Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public ActionResult<EspecialidadeResponse> Editar(int id, [FromBody] EspecialidadeEditarRequest request)
    {
        EspecialidadeResponse response = especialidadesAppServico.Editar(id, request);

        return Ok(response);
    }

    /// <summary>
    /// Exclui uma especialidade por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult Excluir(int id)
    {
        especialidadesAppServico.Excluir(id);

        return Ok();
    }     
}
