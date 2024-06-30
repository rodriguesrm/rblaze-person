using RBlaze.Person.Domain.Entities;

namespace RBlaze.Person.Domain.Repositories
{

    /// <summary>
    /// Interface de repositório de busca de informações da entidade na base de dados
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade de domínio</typeparam>
    /// <typeparam name="TKey">Tipo da chave primária da entidade</typeparam>
    public interface IGetRepository<TEntity, TKey>
        where TEntity : class, IDomainEntity<TKey>
        where TKey : struct
    {

        /// <summary>
        /// Obter os dados de uma única instância da entidade pela chave
        /// </summary>
        /// <param name="key">Valor da chave primária do registro da entidade</param>
        Task<TEntity> GetByKey(TKey key);

        /// <summary>
        /// Obter todos os registros da entidade de forma paginada
        /// </summary>
        /// <param name="pageNumber">Página a ser retornada</param>
        /// <param name="rowsPerPage">Quantidade de registros por página</param>
        Task<IEnumerable<TEntity>> GetAllPagination(uint? pageNumber = null, uint? rowsPerPage = null);

    }
}
