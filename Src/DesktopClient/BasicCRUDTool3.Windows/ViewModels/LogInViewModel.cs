using BasicCRUDTool3.Data.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Text;

namespace BasicCRUDTool3.Windows.ViewModels
{
    public class LogInViewModel : ViewModel
    {
        #region Private Properties
        private ISQLConnectionCredentials SQLConnectionCredentials { get; }
        #endregion

        #region Public Properties
        [Required]
        public string UserID { get; set; }
        [Required]
        public string Database { get; set; }
        [Required]
        public string Host { get; set; }
        [Required]
        public string Password { get; set; }
        #endregion

/*        public void SetSQLConnectionCredentials()
        {
            SQLConnectionCredentials.UserID = UserID;
            SQLConnectionCredentials.Database = Database;
            SQLConnectionCredentials.Host = Host;
            SQLConnectionCredentials.Password = Password;
        }*/

/*        public bool AreCredentialsValid()
        {

            string connectionString = $"Host={Host};Database={Database};Username={UserID};Password={Password}";
            Console.Write(connectionString);
            using NpgsqlConnection connect = new NpgsqlConnection(connectionString);
            try
            {
                connect.Open();
                if (connect.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }*/

/*        public void OnSubmit()
        {
            if (AreCredentialsValid())
            {
                SetSQLConnectionCredentials();
                Console.WriteLine("Connection Valid");
            }
            else
            {
                Console.WriteLine("Connection Invalid");
            }
        }*/
    }
}
