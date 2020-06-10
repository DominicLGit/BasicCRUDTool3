using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace BasicCRUDTool3.Data.Tests.FunctionalTests
{
    [TestClass]
    public class DatabaseScenarioTests
    {
        [TestMethod]
        public void CanConnectToDataBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<Appsettings>();

            var configuration = builder.Build();


            using NpgsqlConnection conn = new NpgsqlConnection(configuration.GetConnectionString("Testing"));
            {
                try
                {
                    conn.Open();
                    Assert.IsTrue(conn.State == ConnectionState.Open);
                }
                catch (NpgsqlException e)
                {
                    Console.WriteLine(e.ToString());
                    Assert.Fail("Connection to test server has failed");
                }
            }

        }

        public class Appsettings
        {
        }
    }
}
