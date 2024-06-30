using RBlaze.Person.Domain.Entities;

namespace RBlaze.Person.Domain.Repositories
{

    /// <summary>
    /// Interface de repositório de exclusão de registro da entidade na base de dados
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade de domínio</typeparam>
    /// <typeparam name="TKey">Tipo da chave primária da entidade</typeparam>
    public interface IDeleteRepository<TEntity, TKey>
        where TEntity : class, IDomainEntity<TKey>
        where TKey : struct
    {

        /// <summary>
        /// Excluir os dados da entidade na base de dados
        /// </summary>
        /// <param name="key">Valor da chave primária do registro da entidade</param>
        /// <param name="entity">Instância da entidade</param>
        void Delete(TKey key, TEntity entity);

    }
}
