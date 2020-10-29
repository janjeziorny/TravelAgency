using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Core
{
    public class UpdateClientViewModel : BaseUpdateViewModel
    {
        public UpdateClientViewModel() : base()
        {
            Table = ApplicationTable.Clients;
            ColumnsNames = DatabaseModel.ClientsInstance.ColumnsToSet;
            Values = DatabaseModel.ClientsInstance.ClientsNamesWithId;
            SelectedColumn = ClientsColumn.birth_date.ToString();
        }

        protected override bool CallAction()
        {
            return DatabaseModel.ClientsInstance.UpdateClient(SelectedColumn, SelectedValue, Value);
        }
    }
}
