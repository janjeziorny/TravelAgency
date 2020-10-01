using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace TravelAgency.Core
{
    /// <summary>
    /// Trips table model
    /// </summary>
    public class Trips : BaseDatabasetable
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="connection">Connection</param>
        public Trips(MySqlConnectionStringBuilder connection) : base(connection)
        {
            Name = ApplicationTable.Trips;            
            GetTable();
        }

        #endregion

        #region Public Operations

        /// <summary>
        /// Add trip function
        /// </summary>
        /// <param name="dateoftrip">Date of trip</param>
        /// <param name="days">Days of trip</param>
        /// <param name="numberofplaces">Number of places</param>
        /// <param name="pilotid">ID of pilot</param>
        /// <param name="priceperperson">Price per person</param>
        /// <returns></returns>
        public bool AddTrip(int priceperperson, int numberofplaces, string dateoftrip, int days, string pilotid)
        {
            return CallStoredProcedure(TravelAgencyStoredProcedures.spAddTrip,

                new List<Parameter>{
                new Parameter { Name = spAddTripParameters.pPPP.ToString(), Value = priceperperson },
                new Parameter { Name = spAddTripParameters.pNOP.ToString(), Value = numberofplaces },
                new Parameter { Name = spAddTripParameters.pTrips_date.ToString(), Value = dateoftrip },
                new Parameter { Name = spAddTripParameters.pDays.ToString(), Value = days },
                new Parameter { Name = spAddTripParameters.pPilot_id.ToString(), Value = DatabasetablesHelpers.ConvertNameToInt(pilotid) }
            });
        }

        /// <summary>
        /// Update trip function
        /// </summary>
        /// <param name="columnName">Name of updateing column</param>
        /// <param name="id">ID of updating trip</param>
        /// <param name="value">Value of updating column</param>
        public bool UpdateTrip(string columnName, int id, object value)
        {
            return CallStoredProcedure(TravelAgencyStoredProcedures.spUpdateTrip,

                new List<Parameter>{
                new Parameter { Name = spUpdateTripParameters.pColumnName.ToString(), Value = columnName },
                new Parameter { Name = spUpdateTripParameters.pId.ToString(), Value = id},
                new Parameter { Name = spUpdateTripParameters.pValue.ToString(), Value = value },
            });
        }

        /// <summary>
        /// Delete trip function
        /// </summary>
        /// <param name="id">ID of deleting trip</param>
        public bool DeleteTrip(int id)
        {
            return CallStoredProcedure(TravelAgencyStoredProcedures.spDeleteTrip,

                new List<Parameter>{
                new Parameter { Name = spDeleteTripParameters.pTrip_id.ToString(), Value = id}
            });
        }

        #endregion
    }
}
