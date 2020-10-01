using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using TravelAgencyFirstShot.Core;

namespace TravelAgencyFirstShot
{
    /// <summary>
    /// Static class that provides information about certain database
    /// </summary>
    public static class DatabaseModel
    {
        #region Private Members

        /// <summary>
        /// MySql database connection setter
        /// </summary>
        private static MySqlConnectionStringBuilder Connection;

        #endregion

        #region Public Properties

        /// <summary>
        /// Instance of <see cref="Clients"/>
        /// </summary>
        public static Clients ClientsInstance { get; set; }

        /// <summary>
        /// Instance of <see cref="Employees"/>
        /// </summary>
        public static Employees EmployeesInstance { get; set; }

        /// <summary>
        /// Instance of <see cref="Orders"/>
        /// </summary>
        public static Orders OrdersInstance { get; set; }

        /// <summary>
        /// Instance of <see cref="Reservations"/>
        /// </summary>
        public static Reservations ReservationsInstance { get; set; }

        /// <summary>
        /// Instance of <see cref="Trips"/>
        /// </summary>
        public static Trips TripsInstance { get; set; }

        /// <summary>
        /// Instance of <see cref="Invoices"/>
        /// </summary>
        public static Invoices InvoicesInstance { get; set; }

        /// <summary>
        /// Instance of <see cref="Payments"/>
        /// </summary>
        public static Payments PaymentsInstance { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets necessary parameters of <see cref="Connection"/>
        /// </summary>
        /// <param name="userid">Id of database user</param>
        /// <param name="password">Password of database user</param>
        public static void SetConnection(string userid, string password)
        {
            Connection = new MySqlConnectionStringBuilder();

            Connection.Server = "travelagency.czkpsglalgom.eu-west-1.rds.amazonaws.com";
            Connection.Database = "travel_agency";
            Connection.UserID = userid;
            Connection.Password = password;
        }

        /// <summary>
        /// Returns true if connection is valid
        /// </summary>
        /// <returns></returns>
        public static bool Connect(string userid, string password)
        {
            // Set connection with user data
            SetConnection(userid, password);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Connection.ToString()))
                {
                    // If connection is valid get this database tables
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    GetTables();

                    conn.Close();

                    return true;
                }
            }
            catch (MySqlException e)
            {
                // Otherwise...
                return false;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets all tables of this database
        /// </summary>
        private static void GetTables()
        {
            ClientsInstance = new Clients(Connection);
            EmployeesInstance = new Employees(Connection);
            OrdersInstance = new Orders(Connection);
            ReservationsInstance = new Reservations(Connection);
            TripsInstance = new Trips(Connection);
            InvoicesInstance = new Invoices(Connection);
            PaymentsInstance = new Payments(Connection);
        }        

        #endregion        
    }
}