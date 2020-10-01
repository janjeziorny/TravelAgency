using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using TravelAgencyFirstShot.Core;

namespace TravelAgencyFirstShot
{
    /// <summary>
    /// Provides methods for <see cref="DatabaseModel"/>
    /// </summary>
    public static class DatabaseOperationHelpers
    {
        /// <summary>
        /// Returns datatable 
        /// </summary>
        /// <param name="pConn">Connection assigned to database</param>
        /// <param name="TableName">Name of table that is extracted</param>
        /// <returns></returns>
        public static DataTable GetTable(MySqlConnection pConn, string TableName)
        {
            //Temporary DataTable object that filled and then returned
            DataTable Table = new DataTable();

            try
            {
                using (MySqlConnection Conn = pConn)
                {
                    // Check whether the connection is open or not
                    if (Conn.State == ConnectionState.Closed)
                    {
                        Conn.Open();
                    }

                    // Command that allows to extract the table
                    using (MySqlCommand comm = new MySqlCommand($"SELECT * FROM `{TableName}`", Conn))
                    {
                        using (MySqlDataAdapter adp = new MySqlDataAdapter(comm))
                        {
                            // Actual filling table
                            comm.ExecuteNonQuery();
                            Table.TableName = TableName;
                            adp.Fill(Table);
                        }
                    }

                    Conn.Close();
                }

                // Return table if successful
                return Table;
            }
            catch (MySqlException e)
            {
                // Return null if unsuccessful
                return null;
            }
        
        }

        /// <summary>
        /// Provides all tables from certain MySql database
        /// </summary>
        /// <param name="pDatabaseConn">Connection assigned to database</param>
        /// <returns></returns>
        public static List<DataTable> GetTables(MySqlConnection pDatabaseConn)
        {
            // Temporary datatables list that is returned
            List<DataTable> tables = new List<DataTable>();

            using (pDatabaseConn)
            {
                try
                {
                    // Check whether the connection is open or not
                    if (pDatabaseConn.State == ConnectionState.Closed)
                    {
                        pDatabaseConn.Open();
                    }

                    // Getting names of views that database is consist of
                    System.Data.DataTable columnsCounter = pDatabaseConn.GetSchema("Views", new string[] { null, null, null, "VIEW" });

                    // Dynamic creating tables and adding them to list of returned tables
                    foreach (DataRow TableNameRow in columnsCounter.Rows)
                    {
                        // Create temporary DataTable object and sets its name
                        string name = $"{TableNameRow["TABLE_NAME"].ToString()}";
                        DataTable temp = new DataTable(name);
                        temp = GetTable(pDatabaseConn, name);
                        tables.Add(temp);
                    }
                }
                catch (MySqlException error)
                {
                    // If the database error occures, returns empty databaseTable object
                    return null;
                }
            }

            return tables;
        }

        /// <summary>
        /// Sets <see cref="Connection"/>.
        /// Returns true if connection is valid.
        /// Returns false if connection is invalid.
        /// </summary>
        /// <param name="UID">User ID</param>
        /// <param name="PASSWORD">Password</param>
        /// <returns></returns>
        public static List<DataTable> Connect(MySqlConnectionStringBuilder Connection)
        {
            List<DataTable> Tables = new List<DataTable>();

            // Check whether connection is valid or not
            using (MySqlConnection connection = new MySqlConnection(Connection.ToString()))
            {
                try
                {
                    // Load tables(views) from MySql database to list of tables
                    Tables = DatabaseOperationHelpers.GetTables(connection);

                    // When the connection is valid return true
                    if (Tables != null)
                        return Tables;
                    return null;
                }
                catch (MySqlException Error)
                {
                    // If the database error occures, returns empty databaseTable object
                    return null;
                }
            }
        }

        /// <summary>
        /// Executes MySql stored procedure (returns "true" if operation is successful)
        /// </summary>
        /// <param name="pConn">Connection with MySql database</param>
        /// <param name="pStoredProcedureName">Name of stored procedure</param>
        /// <param name="pParametersNames">Names of parameters of stroed procedure</param>
        /// <param name="pParametersValue">Values of parameters of stroed procedure</param>
        /// <returns></returns>
        public static bool ExecStoredProcedure(MySqlConnection pConn, string pStoredProcedureName, List<Parameter> pParameters)
        {
            if (pParameters == null)
            {
                return false;
            }

            try
            {
                using (MySqlConnection conn = pConn)
                {
                    using (MySqlCommand CallProcedure = new MySqlCommand(pStoredProcedureName, conn))
                    {
                        // Changing type of command on CommandType.StoredProcedure
                        CallProcedure.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        foreach (Parameter parameter in pParameters)
                        {
                            CallProcedure.Parameters.AddWithValue(parameter.Name, parameter.Value);
                        }

                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        // Actual executing of stored procedure
                        MySqlDataReader Exec = CallProcedure.ExecuteReader();

                        //Closing connections
                        Exec.Close();
                        conn.Close();
                    }
                }

                //True if successful
                return true;
            }
            catch (DbException e)
            {
                //False if unsuccessful
                return false;
            }
        }

        /// <summary>
        /// Prepairs name of certain table to send it as a database query
        /// </summary>
        /// <param name="tableName">Name of table</param>
        /// <returns></returns>
        public static string TableCallerBuilder(string tableName)
        {
            return $"[sel{tableName.ToLower()}]";
        }
    }
}
