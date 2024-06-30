namespace RBlaze.Person.Domain.Entities
{

    /// <summary>
    /// Interface de autor de criação da entidade
    /// </summary>
    public interface ICreatedAuthor
    {

        #region Properties

        /// <summary>
        /// Data de criação da entidade
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Id do autor da criação da entidade
        /// </summary>
        int CreatedBy { get; set; }

        #endregion

    }

}
