using Clinica.DoPovo.Dominio.Consultas.Entidades;
using Clinica.DoPovo.Dominio.Consultas.Servicos.Comandos;

namespace Clinica.DoPovo.Dominio.Consultas.Servicos.Interfaces;

public interface IConsultaServico
{
    Consulta Validar(int id);
    Consulta Inserir(ConsultaInstanciarComando comando);
    Consulta Instanciar(ConsultaInstanciarComando comando);
    Consulta Editar(int id, ConsultaEditarComando comando);
}
