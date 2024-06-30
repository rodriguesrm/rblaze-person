using System.ComponentModel;

namespace RBlaze.Person.Domain.Enums
{
    public enum PhoneType
    {

        /// <summary>
        /// Telefone Celular
        /// </summary>
        [Description("Celular")]
        Cell = 1,

        /// <summary>
        /// Telefone residencial
        /// </summary>
        [Description("Residencial")]
        Home = 2,

        /// <summary>
        /// Telefone comercial/trabalho
        /// </summary>
        [Description("Comercial")]
        Business = 3,

        /// <summary>
        /// Telefone de recado
        /// </summary>
        [Description("Recado")]
        Contact = 4

    }
}
