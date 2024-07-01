namespace RBlaze.Person.Infrastructure.Databases
{

    /// <summary>
    /// Soft deletion interface
    /// </summary>
    internal interface ISoftDeletion
    {

        /// <summary>
        /// Sinalizador de exclusão lógica
        /// </summary>
        bool IsDeleted { get; set; }

    }

}
