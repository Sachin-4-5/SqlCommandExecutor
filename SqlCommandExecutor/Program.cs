using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SqlCommandExecutor
{
    public class Program
    {
        public static void Main()
        {
            SqlCommandExecutor executor = new SqlCommandExecutor();

            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1 - Execute SQL Query");
            Console.WriteLine("2 - Execute Stored Procedure");
            Console.WriteLine("3 - Execute Batch Queries");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Enter query key (e.g., GetEmployeeCount, InsertEmployee):");
                string queryKey = Console.ReadLine();

                Dictionary<string, object> parameters = null;
                if (queryKey == "InsertEmployee")
                {
                    parameters = new Dictionary<string, object>
                    {
                        { "@Name", "Manohar Prasad" },
                        { "@Age", 32 },
                        { "@Dept", "Sales" }
                    };
                }

                executor.ExecuteQuery(queryKey, parameters);
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter stored procedure key (e.g., RunStoredProc):");
                string procKey = Console.ReadLine();

                var parameters = new Dictionary<string, object> { { "@EmployeeId", 2 } };
                executor.ExecuteStoredProcedure(procKey, parameters);
            }
            else if (choice == "3")
            {
                executor.ExecuteBatch("BatchExecution");
            }

            Console.WriteLine("Execution complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
