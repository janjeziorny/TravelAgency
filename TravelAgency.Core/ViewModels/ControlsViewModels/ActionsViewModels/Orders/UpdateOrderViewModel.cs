using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class UpdateOrderViewModel : BaseUpdateViewModel
    {
        public UpdateOrderViewModel() : base()
        {
            Table = ApplicationTable.Orders;
            ColumnsNames = DatabaseModel.OrdersInstance.ColumnsToSet;
            Values = DatabaseModel.OrdersInstance.OrdersNamesWithId;

            SelectedColumn = OrdersColumn.order_date.ToString();
            Value = Values[0];
        }

        protected override bool CallAction()
        {
            return DatabaseModel.OrdersInstance.UpdateOrder(SelectedColumn, SelectedValue, Value);
        }

        protected override object GetParameter()
        {
            return Value;
        }
    }
}
