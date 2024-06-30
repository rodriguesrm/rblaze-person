using System.ComponentModel;

namespace RBlaze.Person.Domain.Enums
{
    public enum PersonType
    {

        /// <summary>
        /// Pessoa física
        /// </summary>
        [Description("Pessoa física")]
        Individual = 1,

        /// <summary>
        /// Pessoa jurídica
        /// </summary>
        [Description("Pessoa jurídica")]
        Company = 2

    }
}
