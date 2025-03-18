using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;


namespace SqlCommandExecutor
{
    public class SqlCommandExecutor
    {
        private readonly string _connectionString;
        public SqlCommandExecutor()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        }




        /// <summary>
        /// Execute a single sql command
        /// </summary>
        public void ExecuteQuery(string queryKey, Dictionary<string, object> parameters = null)
        {
            string query = ConfigurationManager.AppSettings[queryKey];
            if (string.IsNullOrEmpty(query))
            {
                Console.WriteLine($"Error: Query key '{queryKey}' not found.");
                LogManager.Log($"Error: Query key '{queryKey}' not found.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if(parameters != null)
                    {
                        foreach(var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    ExecuteCommand(cmd, queryKey); 
                }
            }
        }





        /// <summary>
        /// Execute a stored procedure
        /// </summary>
        public void ExecuteStoredProcedure(string storedProcKey, Dictionary<string, object> parameters)
        {
            string storedProcName = ConfigurationManager.AppSettings[storedProcKey];

            if (string.IsNullOrEmpty(storedProcName))
            {
                Console.WriteLine($"Error: Stored procedure key '{storedProcKey}' not found.");
                LogManager.Log($"Error: Stored procedure key '{storedProcKey}' not found.");
                return;
            }

            using (SqlConnection conn = new SqlConnection( _connectionString ))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(storedProcName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach(var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                    ExecuteCommand(cmd, storedProcKey);
                }
            }
        }





        /// <summary>
        /// Execute multiple sql command in a batch
        /// </summary>
        public void ExecuteBatch(string batchKey)
        {
            string batchQuery = ConfigurationManager.AppSettings[batchKey];

            if (string.IsNullOrEmpty(batchQuery))
            {
                Console.WriteLine($"Error: Batch key '{batchKey}' not found.");
                LogManager.Log($"Error: Batch key '{batchKey}' not found.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(batchQuery, conn))
                {
                    ExecuteCommand(cmd, batchKey);
                }
            }
        }




        /// <summary>
        /// Common method to execute a sql command
        /// </summary>
        public void ExecuteCommand(SqlCommand cmd, string key)
        {
            try
            {
                if(cmd.CommandText.Trim().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        Console.WriteLine($"Results for '{key}':");
                        while(dr.Read())
                        {
                            for(int i=0; i<dr.FieldCount; i++)
                            {
                                Console.Write($"{dr.GetName(i)}: {dr[i]}  ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Query '{key}' executed. Rows affected: {rowsAffected}");
                    LogManager.Log($"Query '{key}' executed. Rows affected: {rowsAffected}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error executing '{key}': {ex.Message}");
                LogManager.Log($"Error executing '{key}': {ex.Message}");
            }
        }
    }
}
