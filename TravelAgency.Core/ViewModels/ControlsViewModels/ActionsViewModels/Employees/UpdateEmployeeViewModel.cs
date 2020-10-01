using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class UpdateEmployeeViewModel : BaseActionViewModel
    {
        #region Public properites

        /// <summary>
        /// List of columns available to update
        /// </summary>
        public List<string> Columns { get; set; } = DatabaseModel.EmployeesInstance.ColumnsToSet;

        /// <summary>
        /// List of clients available to update
        /// </summary>
        public List<string> Employees { get; set; } = DatabaseModel.EmployeesInstance.EmployeesNamesWithId;

        /// <summary>
        /// Value of updated column
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Selected column
        /// </summary>
        public string SelectedColumn { get; set; }

        /// <summary>
        /// Selected client
        /// </summary>
        public string SelectedEmployee { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateEmployeeViewModel() : base()
        {
            ActionButtonContent = "Update employee";

            SelectedEmployee = Employees[0];
            SelectedColumn = Columns[0];
        }

        #endregion

        #region Protected methods
        protected override bool CallAction()
        {
            return DatabaseModel.EmployeesInstance.UpdateEmployee(SelectedColumn, SelectedEmployee, Value);
        }

        #endregion
    }
}
