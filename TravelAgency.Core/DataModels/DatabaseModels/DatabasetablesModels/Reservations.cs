using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TravelAgency.Core
{
    /// <summary>
    /// Reservations table model
    /// </summary>
    public class Reservations : BaseDatabasetable
    {
        #region Public properties

        /// <summary>
        /// List of reservations IDs combined with names of client
        /// </summary>
        public List<string> ReservationsWithId => DatabasetablesHelpers.CombineIdWithName(GetId(), Table.AsEnumerable().Select(r => r.Field<string>(2)).ToList());

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="connection">Connection</param>
        public Reservations(MySqlConnectionStringBuilder connection) : base(connection)
        {
            Name = ApplicationTable.Reservations;
            GetTable();
        }

        #endregion

        #region Public Operations

        /// <summary>
        /// Add reservation function
        /// </summary>
        /// <param name="bookedplaces">Number of booked places</param>
        /// <param name="clientid">ID of client</param>
        /// <param name="tripid">ID of trip</param>
        /// <returns></returns>
        public bool AddReservation(string clientid, int bookedplaces, int tripid)
        {
            return CallStoredProcedure(TravelAgencyStoredProcedures.spAddReservation,

                new List<Parameter>{
                new Parameter { Name = spAddReservationParameters.pClient_id.ToString(), Value = DatabasetablesHelpers.ConvertNameToInt(clientid) },
                new Parameter { Name = spAddReservationParameters.pBooked_places.ToString(), Value = bookedplaces },
                new Parameter { Name = spAddReservationParameters.pTrip_id.ToString(), Value = tripid }
            });
        }

        /// <summary>
        /// Confirm reservation function
        /// </summary>
        /// <param name="reservationId">ID of reservation</param>
        public bool ConfirmReservation(string reservationId)
        {
            return CallStoredProcedure(TravelAgencyStoredProcedures.spConfirmReservation,

                new List<Parameter>{
                new Parameter { Name = spConfirmReservationParameters.pOrder_id.ToString(), Value = DatabasetablesHelpers.ConvertNameToInt(reservationId) }
            });
        }

        /// <summary>
        /// Delete reservation function
        /// </summary>
        /// <param name="reservationId">ID of reservation</param>
        public bool DeleteReservation(string reservationId)
        {
            return CallStoredProcedure(TravelAgencyStoredProcedures.spDeleteReservation,

                new List<Parameter>{
                new Parameter { Name = spDeleteReservationParameters.pOrder_id.ToString(), Value = DatabasetablesHelpers.ConvertNameToInt(reservationId) }
            });
        }

        #endregion
    }
}
