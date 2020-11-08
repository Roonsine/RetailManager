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
    internal class SqlDataAccess : IDisposable
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

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        // Open connect/start transaction method
        public void StartTransaction(string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();

            isClosed = false;
        }

        // Load using the transaction
        public List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters)
        {
            List<T> rows = _connection.Query<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();

            return rows;           
        }

        // Save using the transaction
        public void SaveDataInTransaction<T>(string storedProcedure, T parameters)
        {           
            _connection.Execute(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        private bool isClosed = false;
        // Close connection/stop transaction method 
        public void CommitTransaction()
        {
            isClosed = true;
            _transaction?.Commit();
            _connection?.Close();
        }

        public void RollBackTransaction()
        {
            isClosed = true;
            _transaction?.Rollback();
            _connection?.Close();
        }

        // Dispose
        public void Dispose()
        {
            if (!isClosed)
            {
                try
                {
                    CommitTransaction();
                }
                catch
                {
                    // TODO - Log this issue.
                }
            }

            _transaction = null;
            _connection = null;
        }
    }
}
