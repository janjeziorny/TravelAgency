using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TravelAgencyFirstShot.Core
{
    /// <summary>
    /// Clients table model
    /// </summary>
    public class Clients : BaseDatabasetable
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="connection">Connection</param>
        public Clients(MySqlConnectionStringBuilder connection) : base(connection)
        {
            Name = ApplicationTable.Clients;
            GetTable();
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Names of views specyfic for <see cref="Clients"/>
        /// </summary>
        private enum ClientsViews
        {
            clientsnames = 0
        }

        #endregion

        #region Public Properties       

        /// <summary>
        /// Names of clients
        /// </summary>
        public List<string> ClientsNames => 
            DatabaseOperationHelpers.GetTable(new MySqlConnection(Connection.ToString()), 
                DatabaseOperationHelpers.TableCallerBuilder(ClientsViews.clientsnames.ToString())).AsEnumerable().Select(r => r.Field<string>(0)).ToList();

        /// <summary>
        /// Returns clients ids combined with their names
        /// </summary>
        /// <returns></returns>
        public List<string> ClientsNamesWithId => DatabasetablesHelpers.CombineIdWithName(GetId(), ClientsNames);

        #endregion

        #region Public Operations

        /// <summary>
        /// Add client function
        /// </summary>
        /// <param name="firstName">Name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="phone">Phone number</param>
        /// <param name="email">Email</param>
        /// <param name="birthDate">Birth date</param>
        /// <param name="locality">Locality</param>
        /// <param name="zip">ZIP code</param>
        /// <param name="throughfore">Throughfore</param>
        /// <param name="gender">Gender</param>
        /// <returns></returns>
        public bool AddClient(string firstName, string lastName, string phone, string email, string birthDate, string locality, string zip, string throughfore, string gender)
        {
            return CallStoredProcedure(TravelAgencyStoredProcedures.spAddClient,

                new List<Parameter>{
                new Parameter { Name = spAddClientsParameters.pFirst_name.ToString(), Value = firstName },
                new Parameter { Name = spAddClientsParameters.pLast_name.ToString(), Value = lastName },
                new Parameter { Name = spAddClientsParameters.pPhone.ToString(), Value = phone },
                new Parameter { Name = spAddClientsParameters.pEmail.ToString(), Value = email },
                new Parameter { Name = spAddClientsParameters.pBirth_date.ToString(), Value = birthDate },
                new Parameter { Name = spAddClientsParameters.pLocality.ToString(), Value = locality },
                new Parameter { Name = spAddClientsParameters.pZip.ToString(), Value = zip },
                new Parameter { Name = spAddClientsParameters.pThoroughfore.ToString(), Value = throughfore },
                new Parameter { Name = spAddClientsParameters.pGender.ToString(), Value = gender }
            });
        }

        /// <summary>
        /// Update client function
        /// </summary>
        /// <param name="columnName">Name of updateing column</param>
        /// <param name="id">ID of updating trip</param>
        /// <param name="value">Value of updating column</param>
        public bool UpdateClient(string columnName, string id, object value)
        {
            return CallStoredProcedure(TravelAgencyStoredProcedures.spUpdateClient,

                new List<Parameter>{
                new Parameter { Name = spUpdateClientParameters.pColumnName.ToString(), Value = columnName },
                new Parameter { Name = spUpdateClientParameters.pId.ToString(), Value = DatabasetablesHelpers.ConvertNameToInt(id)},
                new Parameter { Name = spUpdateClientParameters.pValue.ToString(), Value = value },
            });
        }
        #endregion
    }
}
