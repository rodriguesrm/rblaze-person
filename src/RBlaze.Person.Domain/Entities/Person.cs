namespace RBlaze.Person.Domain.Entities
{

    /// <summary>
    /// Entidade de pessoa
    /// </summary>
    public sealed class Person : IDomainEntity<uint>
    {

        public uint Id { get; set; }

        public uint GetKeyValue() => Id;
    }
}
