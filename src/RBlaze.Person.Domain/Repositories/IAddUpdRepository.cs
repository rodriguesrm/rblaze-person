using RBlaze.Person.Domain.Entities;

namespace RBlaze.Person.Domain.Repositories
{

    /// <summary>
    /// Interface de repositório de criação/alteração da entidade
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade de domínio</typeparam>
    /// <typeparam name="TKey">Tipo da chave primária da entidade</typeparam>
    public interface IAddUpdRepository<TEntity, TKey> 
        where TEntity : class, IDomainEntity<TKey>
        where TKey : struct
    {

        /// <summary>
        /// Persistir a entidade na base de dados, criando uma nova se não existir ou atualizando uma existente
        /// </summary>
        /// <param name="key">Valor da chave primária do registro da entidade</param>
        /// <param name="entity">Instância de <seealso cref="TEntity"/></param>
        public Task<TEntity> AddOrUpdateAsync(TKey key, TEntity entity);

    }
}
