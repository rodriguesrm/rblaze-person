using DomainPerson = RBlaze.Person.Domain.Entities.Person;

namespace RBlaze.Person.Domain.Repositories.Persons
{

    ///<inheritdoc/>
    public interface IDeletePersonRepository : IDeleteRepository<DomainPerson, int>
    {
    }
}
