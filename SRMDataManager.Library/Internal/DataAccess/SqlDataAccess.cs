using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMDataManager.Library.Internal.DataAccess
{/// <summary>
/// This class just interacts with the other data access scripts and the sql database. This prevents
/// any kind of attack towards the database, and prevents the access objects from interacting with 
/// the database. Only this script interacts with the sql database in this library project, all 
/// others reference to this script in order to understand how to get data information.
/// </summary>
    internal class SqlDataAccess
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        
        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedProcedure, parameters, 
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);

            }
        }
    }
}
