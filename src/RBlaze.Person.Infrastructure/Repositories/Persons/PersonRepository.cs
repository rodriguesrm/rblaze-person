using RBlaze.Person.Domain.Repositories.Persons;
using DomainPerson = RBlaze.Person.Domain.Entities.Person;

namespace RBlaze.Person.Infrastructure.Repositories.Persons
{

    /// <summary>
    /// Repositório de persistência de consulta de pessoas
    /// </summary>
    public class PersonRepository : 
        IAddUpdPersonRepository, 
        IGetPersonRepository,
        IDeletePersonRepository
    {

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

    }
}
