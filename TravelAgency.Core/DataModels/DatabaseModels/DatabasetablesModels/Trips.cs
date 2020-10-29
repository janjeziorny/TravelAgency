using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TravelAgency.Core
{
    /// <summary>
    /// Trips table model
    /// </summary>
    public class Trips : BaseDatabasetable
    {
        #region Private Members

        private enum tripsViews
        {
            tripstatuses
        }

        private DataTable Statuses => DatabaseOperationHelpers.GetTable(new MySqlConnection(Connection.ToString()), DatabaseOperationHelpers.TableCallerBuilder(tripsViews.tripstatuses.ToString()));

        #endregion

        #region Private Methods

        /// <summary>
        /// Get number of booked places for specified trip.
        /// If operation was walid, return number of participants.
        /// Else return (-1)
        /// </summary>
        /// <param name="tripId">Trip ID</param>
        /// <returns></returns>
        private int GetBookedPlaces(int tripId)
        {
            // Get id of trip
            var id = (from row in Table.AsEnumerable()
                      where row.Field<int>(TripsColumn.trip_id.ToString()) == tripId
                      select row[TripsColumn.booked_places.ToString()]).ToList();

            // Get number of participants
            var numberOfParticipants = (from row in Table.AsEnumerable()
                       where row.Field<int>(TripsColumn.trip_id.ToString()) == tripId
                       select row[TripsColumn.number_of_participants.ToString()]).ToList();

            // If the values were valid, return number of participants,
            // else return -1
            return id.Count == 1 ? Convert.ToInt32(numberOfParticipants[0]) - Convert.ToInt32(id[0]) : (-1);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get list of places for specified trip as <see cref="List{int}<"/>
        /// </summary>
        /// <param name="tripId">Trip ID</param>
        /// <returns></returns>
        public List<int> BookedPlacesToList(int tripId)
        {
            List<int> places = new List<int>();

            for(int i = 1; i<= GetBookedPlaces(tripId); i++)
            {
                places.Add(i);
            }            
            return places;
        }

        /// <summary>
        /// Get list of places for specified trip as <see cref="List{int}<"/>
        /// </summary>
        /// <param name="tripId">Trip ID</param>
        /// <returns></returns>
        public List<int> BookedPlacesToList(string tripId)
        {
            List<int> places = new List<int>();

            for (int i = 1; i <= GetBookedPlaces(DatabasetablesHelpers.ConvertNameToInt(tripId)); i++)
            {
                places.Add(i);
            }
            return places;
        }

        public List<string> TripsStatusesNamesWithId => DatabasetablesHelpers.CombineIdWithName(Statuses.AsEnumerable().Select(x=>x[0].ToString()).ToList(),
            Statuses.AsEnumerable().Select(x => x[1].ToString()).ToList());


        #endregion

        #region Public Properties

        public List<string> TripsNamesWithId => 
            DatabasetablesHelpers.CombineIdWithName(GetId(), Table.AsEnumerable().Select(x => x[TripsColumn.city.ToString()].ToString()).ToList());

        #endregion

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
        public bool AddTrip(int priceperperson, int numberofplaces, string dateoftrip, int days, string pilotid, string city)
        {
            return CallStoredProcedure(TravelAgencyStoredProcedures.spAddTrip,

                new List<Parameter>{
                new Parameter { Name = spAddTripParameters.pPPP.ToString(), Value = priceperperson },
                new Parameter { Name = spAddTripParameters.pNOP.ToString(), Value = numberofplaces },
                new Parameter { Name = spAddTripParameters.pTrips_date.ToString(), Value = dateoftrip },
                new Parameter { Name = spAddTripParameters.pDays.ToString(), Value = days },
                new Parameter { Name = spAddTripParameters.pPilot_id.ToString(), Value = DatabasetablesHelpers.ConvertNameToInt(pilotid) },
                new Parameter { Name = spAddTripParameters.pCity.ToString(), Value = city },

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
            if (columnName == TripsColumn.name.ToString())
                value = DatabasetablesHelpers.ConvertNameToInt((string)value);
            if (columnName == TripsColumn.pilot.ToString())
                value = DatabasetablesHelpers.ConvertNameToInt((string)value);

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
