using Clinica.DoPovo.Aplicacao.Medicos.Servicos.Interfaces;
using Clinica.DoPovo.DataTransfer.Medicos.Request;
using Clinica.DoPovo.DataTransfer.Medicos.Response;
using Clinica.DoPovo.Dominio.Util;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.DoPovo.API.Controllers.Medicos;

[ApiController]
[Route("api/medicos")]

public class MedicosController : ControllerBase
{
    private readonly IMedicosAppServico medicosAppServico;

    public MedicosController(IMedicosAppServico medicosAppServico)
    {
        this.medicosAppServico = medicosAppServico;
    }

    /// <summary>
    /// Recupera um médico por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<MedicoResponse> Recuperar(int id)
    {
        MedicoResponse response = medicosAppServico.Recuperar(id);
        
        return Ok(response);
    }

    /// <summary>
    /// Lista os médicos com paginação
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<PaginacaoConsulta<MedicoResponse>> Listar([FromQuery] MedicoListarRequest request)
    {
        var response = medicosAppServico.Listar(request);

        return Ok(response);
    }

    /// <summary>
    /// Adiciona um novo médico
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<MedicoResponse> Inserir ([FromBody] MedicoInserirRequest request)
    {
        MedicoResponse response = medicosAppServico.Inserir(request);

        return Ok(response);
    }

    /// <summary>
    /// Edita um médico por Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public ActionResult<MedicoResponse> Editar(int id, [FromBody] MedicoEditarRequest request)
    {
        MedicoResponse response = medicosAppServico.Editar(id, request);

        return Ok(response);
    }

    /// <summary>
    /// Exclui um médico por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult Excluir(int id)
    {
        medicosAppServico.Excluir(id);

        return Ok();
    }

    /// <summary>
    /// Adiciona uma ou mais especialidades ao médico
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("especialidades")]
    public ActionResult<MedicoResponse> AdicionarEspecialidade ([FromBody] MedicoAdicionarEspecialidadeRequest request)
    {
        MedicoResponse response = medicosAppServico.AdicionarEspecialidade(request);

        return Ok(response);
    }

    /// <summary>
    /// Exclui uma ou mais especialidades do médico
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("especialidades")]
    public ActionResult<MedicoResponse> RemoverEspecialidade ([FromBody] MedicoRemoverEspecialidadeRequest request)
    {
        MedicoResponse response = medicosAppServico.RemoverEspecialidade(request);

        return Ok(response);
    }
}
