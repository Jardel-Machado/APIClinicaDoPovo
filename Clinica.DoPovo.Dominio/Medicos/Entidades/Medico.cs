using Clinica.DoPovo.Dominio.Especialidades.Entidades;

namespace Clinica.DoPovo.Dominio.Medicos.Entidades;

public class Medico
{
    public virtual int Id {get; protected set;}
    public virtual string Nome {get; protected set;}
    public virtual string Crm {get; protected set;}
    public virtual IList<Especialidade> Especialidades {get; protected set;} = new List<Especialidade>();

    protected Medico()
    {

    }
    public Medico(string nome, string crm)
    {
        SetNome(nome);
        SetCrm(crm);        
    }

    public virtual void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("Nome não pode ser nulo!");
        }

        if (nome.Length > 100)
        {
            throw new ArgumentException("Nome não pode mais de 100 caracteres!");
        }

        Nome = nome;
    }

    public virtual void SetCrm(string crm)
    {
        if (string.IsNullOrWhiteSpace(crm))
        {
            throw new ArgumentException("Crm não pode ser nulo!");
        }

        if (crm.Length < 4 && crm.Length > 13)
        {
            throw new ArgumentException("Crm não pode menos de 4 e mais de 13 caracteres!");
        }

        Crm = crm;
    }

}
