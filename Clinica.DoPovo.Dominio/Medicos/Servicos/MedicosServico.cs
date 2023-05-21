using Clinica.DoPovo.Dominio.Especialidades.Entidades;
using Clinica.DoPovo.Dominio.Especialidades.Servicos.Interfaces;
using Clinica.DoPovo.Dominio.Medicos.Entidades;
using Clinica.DoPovo.Dominio.Medicos.Repositorios;
using Clinica.DoPovo.Dominio.Medicos.Servicos.Comandos;
using Clinica.DoPovo.Dominio.Medicos.Servicos.Interfaces;

namespace Clinica.DoPovo.Dominio.Medicos.Servicos;

public class MedicosServico : IMedicosServico
{
    private readonly IMedicosRepositorio medicosRepositorio;
    private readonly IEspecialidadeServico especialidadesServico;

    public MedicosServico(IMedicosRepositorio medicosRepositorio, IEspecialidadeServico especialidadesServico)
    {
        this.medicosRepositorio = medicosRepositorio;
        this.especialidadesServico = especialidadesServico;
    }  

    public Medico Editar(int id, MedicoEditarComando comando)
    {
        Medico medico = Validar(id);

        medico.SetNome(comando.Nome);

        medico.SetCrm(comando.Crm);        

        return medicosRepositorio.Editar(medico);    
    }

    public Medico Inserir(MedicoInstanciarComando comando, IList<int> especialidades)
    {
        Medico medico = Instanciar(comando);

        medicosRepositorio.Inserir(medico);

        foreach (int idEspecialidade in especialidades)
        {
            Especialidade especialidade =  especialidadesServico.Validar(idEspecialidade);

            medico.Especialidades.Add(especialidade);
        }       

        return medico;
    }

    public Medico Instanciar(MedicoInstanciarComando comando)
    {
        return new Medico (comando.Nome, comando.Crm);
    }

    public Medico AdiconarEspecialidade(int id, MedicoAdicionarEspecialidadeComando comando)
    {
        Medico medico = Validar(id);

        foreach (int idEspecialidade in comando.Especialidades)
        {
            Especialidade especialidade = especialidadesServico.Validar(idEspecialidade);

            if (medico.Especialidades.Count != 0 && medico.Especialidades.Any(p => p.Id == especialidade.Id))
            {
                throw new ArgumentException("Especialidade já está vinculada ao Médico!");
            }           

            medico.Especialidades.Add(especialidade);
        }

        return medico;  
    }

    public Medico RemoverEspecialidade(int id, MedicoRemoverEspecialidadeComando comando)
    {
        Medico medico = Validar(id);

        foreach (int idEspecialidade in comando.Especialidades)
        {
            Especialidade especialidade = especialidadesServico.Validar(idEspecialidade);

            if (medico.Especialidades.Count != 0 && !medico.Especialidades.Any(p => p.Id == especialidade.Id))
            {
                throw new ArgumentException("Especialidade não está vinculada ao Médico!");
            }           

            medico.Especialidades.Remove(especialidade);
        }

        return medico;  
    }

    public Medico Validar(int id)
    {
        Medico medico = medicosRepositorio.Recuperar(id);

        if (medico == null)
        {
            throw new ArgumentException("Paciente não encontrado!");
        }

        return medico;
    }
}
