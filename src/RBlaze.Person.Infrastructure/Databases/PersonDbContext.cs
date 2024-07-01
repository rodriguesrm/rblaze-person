using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using RBlaze.Person.Domain.Entities;
using RBlaze.Person.Domain.Notifications;
using System.Linq.Expressions;

namespace RBlaze.Person.Infrastructure.Databases
{

    ///<inheritdoc/>
    internal class PersonDbContext(DbContextOptions options) : DbContext(options)
    {

        #region Local objects/variables

        private const string createdOn = nameof(IAudit.CreatedOn);
        private const string changedOn = nameof(IAudit.ChangedOn);
        private const string createdBy = nameof(IAudit.CreatedBy);
        private const string changedBy = nameof(IAudit.ChangedBy);

        #endregion

        #region Overrides

        ///<inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Tables configuration
            SetTableConfiguration(modelBuilder);

            // Applying context model settings based on interface implementation
            SetSoftDeletionConfiguration(modelBuilder);
            SetAuditConfiguration(modelBuilder);
            SetActiveConfiguration(modelBuilder);
            SetIgnoreConfiguration(modelBuilder);

            // Logical exclusion filter
            SoftDeletionFilter(modelBuilder);

            // Entities to ignore
            modelBuilder.Ignore<Notification>();

            base.OnModelCreating(modelBuilder);

        }

        ///<inheritdoc/>
        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        ///<inheritdoc/>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region Local methods

        /// <summary>
        /// Definir configurações de tabelas
        /// </summary>
        /// <param name="modelBuilder">Objeto construtor de modelo</param>
        protected void SetTableConfiguration(ModelBuilder modelBuilder)
        {
            //TODO: NotImplementedException
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converter expressão de filtro em expressão lambda
        /// </summary>
        /// <typeparam name="TInterface">Tipo de onterface</typeparam>
        /// <param name="filterExpression">Expressão de filtro</param>
        /// <param name="entityType">Tipo de entidade</param>
        private static LambdaExpression ConvertFilterExpression<TInterface>(Expression<Func<TInterface, bool>> filterExpression, Type entityType)
        {
            ParameterExpression param = Expression.Parameter(entityType);
            Expression request = ReplacingExpressionVisitor.Replace(filterExpression.Parameters.Single(), param, filterExpression.Body);
            return Expression.Lambda(request, param);
        }

        /// <summary>
        /// Filtra registros com exclusão lógica
        /// </summary>
        private static void SoftDeletionFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes()
                .Where(f => typeof(ISoftDeletion).IsAssignableFrom(f.ClrType))
                .ToList()
                .ForEach(e =>
                {
                    modelBuilder.Entity(e.ClrType)
                        .HasQueryFilter(ConvertFilterExpression<ISoftDeletion>(x => !x.IsDeleted, e.ClrType));
                });
        }

        /// <summary>
        /// Configurar campos de entidade que implementam ISoftDeletion
        /// </summary>
        /// <param name="modelBuilder">Objeto construtor de modelo</param>
        private static void SetSoftDeletionConfiguration(ModelBuilder modelBuilder)
        {

            modelBuilder.Model.GetEntityTypes()
           .Where(f => typeof(ISoftDeletion).IsAssignableFrom(f.ClrType))
           .ToList()
           .ForEach(e =>
           {
               modelBuilder.Entity(e.ClrType)
                   .Property<bool>(nameof(ISoftDeletion.IsDeleted))
                   .HasColumnType("bit")
                   .HasDefaultValue(false)
                   .IsRequired();
           });

        }

        /// <summary>
        /// Configurar campos de entidade que implementam IActive
        /// </summary>
        /// <param name="modelBuilder">Objeto construtor de modelo</param>
        private static void SetActiveConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes()
           .Where(f => typeof(IActive).IsAssignableFrom(f.ClrType))
           .ToList()
           .ForEach(e =>
           {
               modelBuilder.Entity(e.ClrType)
                   .Property<bool>(nameof(IActive.IsActive))
                   .HasColumnType("bit")
                   .IsRequired();
           });
        }

        /// <summary>
        /// Configurar campos de entidade que implementam IAudit
        /// </summary>
        /// <param name="modelBuilder">Objeto construtor de modelo</param>
        private static void SetAuditConfiguration(ModelBuilder modelBuilder)
        {

            modelBuilder.Model.GetEntityTypes()
            .Where(f => typeof(IAudit).IsAssignableFrom(f.ClrType) || typeof(ICreatedAuthor).IsAssignableFrom(f.ClrType))
            .ToList()
            .ForEach(e =>
            {
                modelBuilder.Entity(e.ClrType)
                    .Property<DateTime>(createdOn)
                    .IsRequired();

                modelBuilder.Entity(e.ClrType)
                    .Property<int>(createdBy)
                    .IsRequired();

                modelBuilder.Entity(e.ClrType)
                    .HasIndex(createdOn)
                    .HasDatabaseName($"IX_{e.ShortName()}_{createdOn}");

                modelBuilder.Entity(e.ClrType)
                    .HasIndex(createdBy)
                    .HasDatabaseName($"IX_{e.ShortName()}_{createdBy}");

                if (typeof(IAudit).IsAssignableFrom(e.ClrType))
                {

                    modelBuilder.Entity(e.ClrType)
                        .Property<int?>(changedBy);

                    modelBuilder.Entity(e.ClrType)
                        .Property<DateTime?>(changedOn);

                    modelBuilder.Entity(e.ClrType)
                        .HasIndex(changedOn)
                        .HasDatabaseName($"IX_{e.ShortName()}_{changedOn}");

                    modelBuilder.Entity(e.ClrType)
                        .HasIndex(changedBy)
                        .HasDatabaseName($"IX_{e.ShortName()}_{changedBy}");

                }

            });
        }

        /// <summary>
        /// Definir os itens (entidades/campos) a serem ignorados na criação do modelo
        /// </summary>
        /// <param name="modelBuilder">Objeto construtor de modelo</param>
        private static void SetIgnoreConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes()
                .Where(f => f is Notifiable)
                .ToList()
                .ForEach(e =>
                {
                    modelBuilder.Entity(e.ClrType)
                        .Ignore(nameof(Notifiable.Notifications))
                        .Ignore(nameof(Notifiable.IsValid))
            ;
                });
        }

        /// <summary>
        /// Evento lançado antes que as informações no banco de dados persistam
        /// </summary>
        private void OnBeforeSaving()
        {

            List<EntityEntry> entities = ChangeTracker.Entries().ToList();
            DateTime now = DateTime.UtcNow;

            // Logical exclusion
            foreach (EntityEntry e in entities.Where(entry => entry.Entity is ISoftDeletion))
            {
                switch (e.State)
                {
                    case EntityState.Added:
                        e.Property(nameof(ISoftDeletion.IsDeleted)).CurrentValue = false;
                        break;

                    case EntityState.Deleted:
                        e.Property(nameof(ISoftDeletion.IsDeleted)).CurrentValue = true;
                        e.State = EntityState.Modified;
                        break;
                }
            }

            // Audit
            foreach (EntityEntry e in entities.Where(f => f.Entity is IAudit))
            {

                switch (e.State)
                {
                    case EntityState.Added:
                        e.Property(createdOn).CurrentValue = now;
                        e.Property(changedOn).CurrentValue = null;
                        break;

                    case EntityState.Modified:
                        e.Property(changedOn).CurrentValue = now;
                        e.State = EntityState.Modified;
                        break;
                }
            }

        }

        #endregion

    }
}
