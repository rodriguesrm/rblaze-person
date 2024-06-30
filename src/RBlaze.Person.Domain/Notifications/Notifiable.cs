namespace RBlaze.Person.Domain.Notifications
{

    /// <summary>
    /// Classe abstrata para criar um objeto notificável
    /// </summary>
    public abstract class Notifiable
    {

        #region Local objects/variables

        private readonly List<Notification> _notifications;

        #endregion

        #region Constructors

        /// <summary>
        /// Crie uma nova instância do objeto
        /// </summary>
        public Notifiable()
        {
            _notifications = [];
        }

        #endregion

        #region Properties

        /// <summary>
        /// Obter lista somente leitura das notificações
        /// </summary>
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        #endregion

        #region Local methods

        /// <summary>
        /// Obtenha uma instância de notificação
        /// </summary>
        /// <param name="key">Chave de propriedade de notificação</param>
        /// <param name="message">Conteúdo da mensagem de notificação</param>
        private static Notification GetNotificationInstance(string key, string message)
            => new(key, message);

        #endregion

        #region Public methods

        /// <summary>
        /// Adicionar uma notificação
        /// </summary>
        /// <param name="key">Chave de propriedade de notificação</param>
        /// <param name="message">Conteúdo da mensagem de notificação</param>
        public void AddNotification(string key, string message)
        {
            var notification = GetNotificationInstance(key, message);
            _notifications.Add(notification);
        }

        /// <summary>
        /// Adicionar uma notificação
        /// </summary>
        /// <param name="notification">Instância de <see cref="Notification"/></param>
        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        /// <summary>
        /// Adicionar uma notificação
        /// </summary>
        /// <param name="property">Uma instância de tipo de propriedade</param>
        /// <param name="message">Conteúdo da mensagem de notificação</param>
        public void AddNotification(Type property, string message)
        {
            ArgumentNullException.ThrowIfNull(property, nameof(property));
            var notification = GetNotificationInstance(property.Name, message);
            _notifications.Add(notification);
        }

        /// <summary>
        /// Adicionar uma notificação
        /// </summary>
        /// <param name="notifications">Lista de notificações</param>
        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        /// <summary>
        /// Adicionar uma notificação
        /// </summary>
        /// <param name="notifications">Lista de notificações</param>
        public void AddNotifications(IList<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        /// <summary>
        /// Adicionar uma notificação
        /// </summary>
        /// <param name="notifications">Lista de notificações</param>
        public void AddNotifications(ICollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        /// <summary>
        /// Adicionar uma notificação
        /// </summary>
        /// <param name="item">Instância de uma entidade notificável</param>
        public void AddNotifications(Notifiable item)
        {
            AddNotifications(item.Notifications);
        }

        /// <summary>
        /// Adicionar uma notificação
        /// </summary>
        /// <param name="items">Lista de instânciasd e entidades notificáveis</param>
        public void AddNotifications(params Notifiable[] items)
        {
            foreach (var item in items)
                AddNotifications(item);
        }

        /// <summary>
        /// Limpar todas as notificações
        /// </summary>
        public void Clear()
        {
            _notifications.Clear();
        }

        /// <summary>
        /// Obtém se o objeto é válido
        /// </summary>
        public bool IsValid
            => !_notifications.Any();

        #endregion

    }
}
