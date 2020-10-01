using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TravelAgencyFirstShot.Core
{
    /// <summary>
    /// Orders table model
    /// </summary>
    public class Orders : BaseDatabasetable
    {
        #region Public properties

        /// <summary>
        /// Names of clients
        /// </summary>
        public List<string> ClientsNames => Table.AsEnumerable().Select(r => r.Field<string>(2)).ToList();

        /// <summary>
        /// Returns orders IDs combined with their names
        /// </summary>
        /// <returns></returns>
        public List<string> OrdersNamesWithId => DatabasetablesHelpers.CombineIdWithName(GetId(), ClientsNames);

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="connection">Connection</param>
        public Orders(MySqlConnectionStringBuilder connection) : base(connection)
        {
            Name = ApplicationTable.Orders;
            GetTable();
        }

        #endregion

        #region Public Operations

        /// <summary>
        /// Add order function
        /// </summary>
        /// <param name="bookedplaces">Number of booked places</param>
        /// <param name="clientid">ID of client</param>
        /// <param name="tripid">ID of trip</param>
        /// <returns></returns>
        public bool AddOrder(string clientid, int bookedplaces, int tripid)
        {
            return CallStoredProcedure(TravelAgencyStoredProcedures.spAddOrder,

                new List<Parameter>{
                new Parameter { Name = spAddOrderParameters.pClient_id.ToString(), Value = DatabasetablesHelpers.ConvertNameToInt(clientid) },
                new Parameter { Name = spAddOrderParameters.pBooked_places.ToString(), Value = bookedplaces },
                new Parameter { Name = spAddOrderParameters.pTrip_id.ToString(), Value = tripid }
            });
        }

        /// <summary>
        /// Update order function
        /// </summary>
        /// <param name="columnName">Name of updating column</param>
        /// <param name="id">ID of updating order</param>
        /// <param name="value">Value of updating column</param>
        public bool UpdateOrder(string columnName, string id, object value)
        {
            return CallStoredProcedure(TravelAgencyStoredProcedures.spUpdateOrders,

                new List<Parameter>{
                new Parameter { Name = spUpdateOrdersParameters.pColumnName.ToString(), Value = columnName },
                new Parameter { Name = spUpdateOrdersParameters.pId.ToString(), Value = DatabasetablesHelpers.ConvertNameToInt(id)},
                new Parameter { Name = spUpdateOrdersParameters.pValue.ToString(), Value = value },
            });
        }
        #endregion
    }
}
