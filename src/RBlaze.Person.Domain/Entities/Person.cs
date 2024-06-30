namespace RBlaze.Person.Domain.Entities
{

    /// <summary>
    /// Entidade de pessoa
    /// </summary>
    public sealed class Person : IDomainEntity<int>
    {
        public int GetKeyValue(IDomainEntity<int> entity)
        {
            throw new NotImplementedException();
        }
    }
}
