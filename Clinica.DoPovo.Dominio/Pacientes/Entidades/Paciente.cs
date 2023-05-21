using Clinica.DoPovo.Dominio.Pacientes.Enumeradores;

namespace Clinica.DoPovo.Dominio.Pacientes.Entidades;

public class Paciente
{
    public virtual int Id { get; protected set; }

    public virtual string Nome { get; protected set; }

    public virtual DateTime DataNascimento { get; protected set; }

    public virtual int Idade { get; protected set; }

    public virtual ConvenioEnum Convenio { get; protected set; }

    protected Paciente()
    {

    }
    public Paciente(string nome, DateTime dataNascimento, ConvenioEnum convenio)
    {
        SetNome(nome);
        SetDataNacimento(dataNascimento);        
        SetConvenio(convenio);
    }
    public virtual void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome não pode ser nulo ou vazio!");
        }

        if (nome.Length < 3 && nome.Length > 100 )
        {
            throw new ArgumentException("O nome deve ter entre 3 e 100 caracteres!");
        }

        Nome = nome;
    }
    public virtual void SetDataNacimento(DateTime dataNascimento)
    {

        DataNascimento = dataNascimento;

        SetIdade();

    }
    public virtual void SetIdade()
    {

        Idade = DateTime.Now.Year - DataNascimento.Year;

        if(DataNascimento.Date > DateTime.Now.AddYears(-Idade))
        {
            Idade --;
        }
    }
    public virtual void SetConvenio(ConvenioEnum convenio)   
    {
        Convenio = convenio;
    }
}
