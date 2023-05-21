using Clinica.DoPovo.Dominio.Especialidades.Entidades;
using Clinica.DoPovo.Dominio.Especialidades.Repositorios;
using Clinica.DoPovo.Dominio.Especialidades.Servicos.Comandos;
using Clinica.DoPovo.Dominio.Especialidades.Servicos.Interfaces;

namespace Clinica.DoPovo.Dominio.Especialidades.Servicos;

public class EspecialidadeServico : IEspecialidadeServico
{
    private readonly IEspecialidadesRepositorio especialidadesRepositorio;

    public EspecialidadeServico(IEspecialidadesRepositorio especialidadesRepositorio)
    {
        this.especialidadesRepositorio = especialidadesRepositorio;
    }

    public Especialidade Editar(int id, EspecialidadeEditarComando comando)
    {
        Especialidade especialidade = Validar(id);

        especialidade.SetDescricao(comando.Descricao);       

        return especialidadesRepositorio.Editar(especialidade);    
    }

    public Especialidade Inserir(EspecialidadeInstanciarComando comando)
    {
        Especialidade especialidade = Instanciar(comando);

        return especialidadesRepositorio.Inserir(especialidade);
    }

    public Especialidade Instanciar(EspecialidadeInstanciarComando comando)
    {
        return new Especialidade(comando.Descricao);
    }

    public Especialidade Validar(int id)
    {
         Especialidade especialidade = especialidadesRepositorio.Recuperar(id);

        if (especialidade == null)
        {
            throw new ArgumentException("Especialidade não encontrada!");
        }

        return especialidade;
    }
}
