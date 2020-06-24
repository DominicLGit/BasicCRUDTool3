using BasicCRUDTool3.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Data.Tests
{
    public class CRUDTestDBContextProvider : ICRUDTestDBContextProvider
    {
        public string databaseID;
        public CRUDTestDBContextProvider(string databaseID)
        {
            this.databaseID = databaseID;
        }
        public CRUDTestDBContext GetContext()
        {
            var option = new DbContextOptionsBuilder<CRUDTestDBContext>()
                .UseInMemoryDatabase(databaseID)
                .UseLazyLoadingProxies();

            return new CRUDTestDBContext(option.Options);
        }
    }
}
 