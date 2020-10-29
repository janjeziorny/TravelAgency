using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class UpdateEmployeeViewModel : BaseUpdateViewModel
    {
        public UpdateEmployeeViewModel() : base()
        {
            Table = ApplicationTable.Employees;
            ColumnsNames = DatabaseModel.EmployeesInstance.ColumnsToSet;
            Values = DatabaseModel.EmployeesInstance.EmployeesNamesWithId;
            SelectedColumn = EmployeesColumn.birth_date.ToString();
        }

        protected override bool CallAction()
        {
            return DatabaseModel.EmployeesInstance.UpdateEmployee(SelectedColumn, SelectedValue, Value);
        }
    }
}
