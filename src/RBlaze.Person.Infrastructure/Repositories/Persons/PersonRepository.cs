using Microsoft.EntityFrameworkCore;
using RBlaze.Person.Domain.Repositories.Persons;
using RBlaze.Person.Infrastructure.Databases;
using DomainPerson = RBlaze.Person.Domain.Entities.Person;

namespace RBlaze.Person.Infrastructure.Repositories.Persons
{

    /// <summary>
    /// Repositório de persistência de consulta de pessoas
    /// </summary>
    /// <remarks>
    /// Cria uma nova instância do repositório
    /// </remarks>
    /// <param name="ctx">Instância do contexto de banco de dados</param>
    internal class PersonRepository(PersonDbContext ctx) : 
        IAddUpdPersonRepository, 
        IGetPersonRepository,
        IDeletePersonRepository
    {

        #region Local objects/variables

        private readonly PersonDbContext _ctx = ctx;
        //private readonly DbSet<PersonTable> _dbSet = ctx.Set<PersonTable>();

        #endregion

        #region Public methods

        ///<inheritdoc/>
        public async Task<DomainPerson> AddOrUpdateAsync(uint key, DomainPerson entity)
        {
            //TODO: NotImplementedException
            
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DomainPerson>> GetAllPagination(uint? pageNumber = null, uint? rowsPerPage = null)
        {
            //TODO: NotImplementedException
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task<DomainPerson> GetByKey(uint key)
        {
            //TODO: NotImplementedException
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public void Delete(uint key, DomainPerson entity)
        {
            //TODO: NotImplementedException
            throw new NotImplementedException();
        }

        #endregion

    }
}
