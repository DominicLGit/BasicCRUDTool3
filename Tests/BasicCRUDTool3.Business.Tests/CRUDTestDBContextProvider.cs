using BasicCRUDTool3.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security;
using System.Text;

namespace BasicCRUDTool3.Business.Tests
{
    public class CRUDTestDBContextProvider : ICRUDTestDBContextProvider
    {
        public CRUDTestDBContext GetContext()
        {
            var option = new DbContextOptionsBuilder<CRUDTestDBContext>()
                .UseInMemoryDatabase("CRUDTestDB")
                .UseLazyLoadingProxies();

            return new CRUDTestDBContext(option.Options);
        }
    }
}
