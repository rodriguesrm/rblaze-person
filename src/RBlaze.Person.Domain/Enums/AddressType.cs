using System.ComponentModel;

namespace RBlaze.Person.Domain.Enums
{
    public enum AddressType
    {

        /// <summary>
        /// Endereço residencial
        /// </summary>
        [Description("Endereço residencial")]
        Home = 1,

        /// <summary>
        /// Endereco comercial/trabalho
        /// </summary>
        [Description("Endereço comercial")]
        Business = 2

    }
}
