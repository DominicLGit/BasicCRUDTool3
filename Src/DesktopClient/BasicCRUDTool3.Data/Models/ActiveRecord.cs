using System;
using System.Runtime.Serialization;

namespace BasicCRUDTool3.Data.Models
{
    /// <summary>
    /// Base active record class that binds to EFCore entity
    /// </summary>
    /// <typeparam name="TEntity">EFCore entity</typeparam>
    /// <typeparam name="TKey">Primary key for entity</typeparam>
    public abstract class ActiveRecord<TEntity, TKey> where TEntity : class, new()
    {
        #region Protected members
        protected readonly ICRUDTestDBContextProvider CRUDTestDBContextProvider;
        protected readonly CRUDTestDBContext Context;
        protected TEntity Entity;
        #endregion

        #region Public Properties
        public TKey Id { get; protected set; }
        #endregion

        #region Constructors
        protected ActiveRecord(ICRUDTestDBContextProvider cRUDTestDBContextProvider)
        {
            CRUDTestDBContextProvider = cRUDTestDBContextProvider;
            Context = cRUDTestDBContextProvider.GetContext();
        }
        #endregion

        #region Public Methods
        public virtual void Load(TKey id)
        {
            Entity = Context.Find<TEntity>(id);
            if (Entity != null)
            {
                Id = id;
            }
            else
            {
                throw new InvalidOperationException($"Entity type {typeof(TEntity).FullName} with key {Id} does not exist.");
            }
        }

        public virtual void New()
        {
            Entity = new TEntity();
            Context.Add(Entity);
        }

        /// <summary>
        /// Deletes Entity from Context and updates database immediately 
        /// </summary>
        public virtual void Delete()
        {
            if (Entity == null)
            {
                throw new InvalidOperationException();
            }

            Context.Remove(Entity);
            Context.SaveChanges();
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }
        #endregion
    }
}
