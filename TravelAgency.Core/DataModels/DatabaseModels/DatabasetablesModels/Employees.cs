using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TravelAgency.Core
{
    /// <summary>
    /// Employees table model
    /// </summary>
    public class Employees : BaseDatabasetable
    {
        #region Private Members

        /// <summary>
        /// Names of views specyfic for <see cref="Employees"/>
        /// </summary>
        private enum EmployeesViews
        {
            positions = 0,
            employeesnames = 1,
            pilots = 2
        }

        /// <summary>
        /// List of positions
        /// </summary>
        private List<string> PositionNames =>
            DatabaseOperationHelpers.GetTable(new MySqlConnection(Connection.ToString()),
                DatabaseOperationHelpers.TableCallerBuilder(EmployeesViews.positions.ToString())).AsEnumerable().Select(r => r.Field<string>(1)).ToList();

        /// <summary>
        /// List of positions
        /// </summary>
        private List<int> PositionId =>
            DatabaseOperationHelpers.GetTable(new MySqlConnection(Connection.ToString()),
                DatabaseOperationHelpers.TableCallerBuilder(EmployeesViews.positions.ToString())).AsEnumerable().Select(r => r.Field<int>(0)).ToList();

        /// <summary>
        /// Names of pilots
        /// </summary>
        private List<string> PilotsNames =>
            DatabaseOperationHelpers.GetTable(new MySqlConnection(Connection.ToString()),
                DatabaseOperationHelpers.TableCallerBuilder(EmployeesViews.pilots.ToString())).AsEnumerable().Select(r => r.Field<string>(2)).ToList();

        /// <summary>
        /// Ids of pilots
        /// </summary>
        private List<int> PilotsId =>
            DatabaseOperationHelpers.GetTable(new MySqlConnection(Connection.ToString()),
                DatabaseOperationHelpers.TableCallerBuilder(EmployeesViews.pilots.ToString())).AsEnumerable().Select(r => r.Field<int>(0)).ToList();

        /// <summary>
        /// Names of employees
        /// </summary>
        private List<string> EmployeesNames =>
            DatabaseOperationHelpers.GetTable(new MySqlConnection(Connection.ToString()),
                DatabaseOperationHelpers.TableCallerBuilder(EmployeesViews.employeesnames.ToString())).AsEnumerable().Select(r => r.Field<string>(0)).ToList();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="connection">Connection</param>
        public Employees(MySqlConnectionStringBuilder connection) : base(connection)
        {
            Name = ApplicationTable.Employees;
            GetTable();
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Positions ID combined with their names
        /// </summary>
        public List<string> PositionNamesWithId => DatabasetablesHelpers.CombineIdWithName(PositionId, PositionNames);

        /// <summary>
        /// Pilots ID combined with thier names
        /// </summary>
        public List<string> PilotsWithId => DatabasetablesHelpers.CombineIdWithName(PilotsId, PilotsNames);

        /// <summary>
        /// Returns clients ids combined with their names
        /// </summary>
        /// <returns></returns>
        public List<string> EmployeesNamesWithId => DatabasetablesHelpers.CombineIdWithName(GetId(), EmployeesNames);

        #endregion

        #region Public Operations        

        /// <summary>
        /// Add employee function
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
        /// <param name="position">Position</param>
        /// <returns></returns>
        public bool AddEmploee(string firstName, string lastName, string phone, string email, string birthDate, string locality, string zip, string throughfore, string gender, string position)
        {
            return CallStoredProcedure(TravelAgencyStoredProcedures.spAddEmployee,

                new List<Parameter>{
                new Parameter { Name = spAddEmployeeParameters.pFirst_name.ToString(), Value = firstName },
                new Parameter { Name = spAddEmployeeParameters.pLast_name.ToString(), Value = lastName },
                new Parameter { Name = spAddEmployeeParameters.pPhone.ToString(), Value = phone },
                new Parameter { Name = spAddEmployeeParameters.pEmail.ToString(), Value = email },
                new Parameter { Name = spAddEmployeeParameters.pBirth_date.ToString(), Value = birthDate },
                new Parameter { Name = spAddEmployeeParameters.pLocality.ToString(), Value = locality },
                new Parameter { Name = spAddEmployeeParameters.pZip.ToString(), Value = zip },
                new Parameter { Name = spAddEmployeeParameters.pThoroughfore.ToString(), Value = throughfore },
                new Parameter { Name = spAddEmployeeParameters.pGender.ToString(), Value = gender },
                new Parameter { Name = spAddEmployeeParameters.pPosition.ToString(), Value = DatabasetablesHelpers.ConvertNameToInt(position) }
            });
        }

        /// <summary>
        /// Update employee function
        /// </summary>
        /// <param name="columnName">Name of updating column</param>
        /// <param name="id">ID of updating employee</param>
        /// <param name="value">Value of updating column</param>
        public bool UpdateEmployee(string columnName, string id, object value)
        {
            return CallStoredProcedure(TravelAgencyStoredProcedures.spUpdateEmployee,

                new List<Parameter>{
                new Parameter { Name = spUpdateEmployeeParameters.pColumnName.ToString(), Value = columnName },
                new Parameter { Name = spUpdateEmployeeParameters.pId.ToString(), Value = DatabasetablesHelpers.ConvertNameToInt(id)},
                new Parameter { Name = spUpdateEmployeeParameters.pValue.ToString(), Value = value },
            });
        }

        #endregion
    }
}
