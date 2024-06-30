namespace RBlaze.Person.Domain.Notifications
{

    /// <summary>
    /// registro de modelo de notificação
    /// </summary>
    /// <param name="Key">Chave de propriedade de notificação</param>
    /// <param name="Message">Conteúdo da mensagem de notificação</param>
    public record Notification
    (

        /// <summary>
        /// Chave de propriedade de notificação
        /// </summary>
        string Key,

        /// <summary>
        /// Conteúdo da mensagem de notificação
        /// </summary>
        string Message

    );

}