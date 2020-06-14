using System;

namespace BasicCRUDTool3.Data.Models
{
    public abstract class ActiveRecord<TEntity, TKey> where TEntity : class, new()
    {
        protected readonly ICRUDTestDBContextProvider CRUDTestDBProvider
    }
}
