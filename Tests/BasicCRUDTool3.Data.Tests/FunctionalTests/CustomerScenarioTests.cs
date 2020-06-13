using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCRUDTool3.Data.Tests.FunctionalTests
{
    public class CustomerScenarioTests
    {
        [TestMethod]
        public void CanCreateCustomer()
        {
            using NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Database=CRUDTestDB;Username=postgres;Password=Password12!");
            {
                try
                {
                    IServiceCollection services = new ServiceCollection();
                    services.AddDbContext
                }
                catch (NpgsqlException e)
                {
                    Console.WriteLine(e.ToString());
                    Assert.Fail("Connection to test server has failed");
                }
            }
        }
    }
}
