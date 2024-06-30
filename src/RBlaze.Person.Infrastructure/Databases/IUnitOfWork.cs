namespace RBlaze.Person.Infrastructure.Databases
{

    /// <summary>
    /// Unit of work interface (transaction)
    /// </summary>
    public interface IUnitOfWork
    {

        #region Properties

        /// <summary>
        /// Indica se a transação foi iniciada
        /// </summary>
        public bool TransactionStarted { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Salva todas as alterações feitas neste contexto no banco de dados
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// Salva todas as alterações feitas neste contexto no banco de dados
        /// </summary>
        /// <param name="cancellationToken">Um <see cref="CancellationToken"/> a ser observado enquanto aguarda a conclusão da tarefa</param>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Inicia uma transação
        /// </summary>
        /// <param name="cancellationToken">Um <see cref="CancellationToken"/> a ser observado enquanto aguarda a conclusão da tarefa</param>
        /// <exception cref="InvalidOperationException">Ocorre quando a transação já foi iniciada</exception>"
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Finalizaça uma transação persistindo as alterações realizadas
        /// </summary>
        /// <param name="cancellationToken">Um <see cref="CancellationToken"/> a ser observado enquanto aguarda a conclusão da tarefa</param>
        /// <exception cref="InvalidOperationException">Ocorre quando a transação não foi iniciada</exception>"
        Task CommitAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Desfaz a transação descartando as alterações realizadas
        /// </summary>
        /// <param name="cancellationToken">Um <see cref="CancellationToken"/> a ser observado enquanto aguarda a conclusão da tarefa</param>
        /// <exception cref="InvalidOperationException">Ocorre quando a transação não foi iniciada</exception>"
        Task RollBackAsync(CancellationToken cancellationToken = default);

        #endregion


    }

}