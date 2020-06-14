using System;
using System.Runtime.Serialization;

namespace BasicCRUDTool3.Data.Models
{
    public abstract class ActiveRecord<TEntity, TKey> where TEntity : class, new()
    {
        #region Protected members
        protected readonly ICRUDTestDBContextProvider CRUDTestDBProvider;
        protected readonly CRUDTestDBContext Context;
        protected TEntity Entity;
        #endregion

        #region Public Properties
        public TKey Id { get; protected set; }
        #endregion

        protected ActiveRecord(ICRUDTestDBContextProvider cRUDTestDBProvider)
        {
            CRUDTestDBProvider = cRUDTestDBProvider;
            Context = cRUDTestDBProvider.GetContext();
        }

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
                throw new InvalidOperationException();
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
