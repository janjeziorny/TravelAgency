using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TravelAgencyFirstShot.Core
{
    /// <summary>
    /// Base table model for our database
    /// </summary>
    public abstract class BaseDatabasetable
    {
        #region Protected Members

        /// <summary>
        /// Contains information about conection
        /// </summary>
        protected MySqlConnectionStringBuilder Connection;

        #endregion

        #region Private Members

        /// <summary>
        /// Names of views for every instance of <see cref="BaseDatabasetable"/>
        /// </summary>
        private enum BaseDatabasetableViews
        {
            columnstoset = 0
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Contains data of table
        /// </summary>
        public DataTable Table { get; set; }

        /// <summary>
        /// Name of this table
        /// </summary>
        public ApplicationTable Name { get; set; }

        /// <summary>
        /// List of columns that the user can set
        /// </summary>
        public List<string> ColumnsToSet =>
            DatabaseOperationHelpers.GetTable((new MySqlConnection(Connection.ToString())), DatabaseOperationHelpers.TableCallerBuilder(Name.ToString() + BaseDatabasetableViews.columnstoset.ToString())).AsEnumerable().Select(r => r.Field<string>(0)).ToList();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="server"></param>
        /// <param name="database"></param>
        public BaseDatabasetable(MySqlConnectionStringBuilder connection)
        {
            Connection = connection;            
        }
        
        #endregion

        #region Protected Methods

        /// <summary>
        /// Loads data into the <see cref="Table"/>
        /// </summary>
        /// <returns></returns>
        protected void GetTable()
        {
            Table = DatabaseOperationHelpers.GetTable((new MySqlConnection(Connection.ToString())), DatabaseOperationHelpers.TableCallerBuilder(Name.ToString()));
        }     

        /// <summary>
        /// Invokes specified Stored Procedure
        /// </summary>
        /// <param name="procedure">Procedure</param>
        /// <param name="values">Values of parameters</param>
        /// <returns></returns>
        protected bool CallStoredProcedure(TravelAgencyStoredProcedures procedure, List<Parameter> values)
        {
            return DatabaseOperationHelpers.ExecStoredProcedure(new MySqlConnection(Connection.ToString()), procedure.ToString(), values);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns table with given name from Tables (null if there's not such a table)
        /// </summary>
        /// <param name="pTableName">Name of table</param>
        /// <returns></returns>
        public DataTable PeekTable()
        {
            GetTable();
            return Table;
        }        

        /// <summary>
        /// Return all id's numbers for this table
        /// </summary>
        /// <returns></returns>
        public List<int> GetId()
        {
            return Table.AsEnumerable().Select(r => r.Field<int>(0)).ToList();
        }     

        #endregion
    }
}
