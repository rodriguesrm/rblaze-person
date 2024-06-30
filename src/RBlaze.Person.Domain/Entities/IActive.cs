namespace RBlaze.Person.Domain.Entities
{

    /// <summary>
    /// Entity active interface
    /// </summary>
    public interface IActive
    {

        /// <summary>
        /// Indicate if entity is active
        /// </summary>
        bool IsActive { get; set; }

    }

}
