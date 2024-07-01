namespace RBlaze.Person.Domain.Entities
{

    /// <summary>
    /// Interface de identificação de entidades de domínio   
    /// </summary>
    /// <typeparam name="TKey">Tipo da chave primária da entidade</typeparam>
    public interface IDomainEntity<TKey>
        where TKey : struct
    {

        /// <summary>
        /// Obter o valor da chave primária de uma entidade
        /// </summary>
        TKey GetKeyValue();

    }
}
