namespace Clinica.DoPovo.Dominio.Especialidades.Entidades;

public class Especialidade
{
    public virtual int Id { get; protected set; }
    public virtual string Descricao { get; protected set; }

    protected Especialidade()
    {
        
    }

    

    public Especialidade(string descricao)
    {
        SetDescricao(descricao);
    }

    public virtual void SetDescricao(string descricao)
    {
        if (string.IsNullOrWhiteSpace(descricao))
        {
            throw new ArgumentException("A descrição não pode ser nula!");
        }

        if (descricao.Length > 100)
        {
            throw new ArgumentException("A descrição não pode ter mais de 100 caracteres!");
        }

        Descricao = descricao;
    }

    


}
