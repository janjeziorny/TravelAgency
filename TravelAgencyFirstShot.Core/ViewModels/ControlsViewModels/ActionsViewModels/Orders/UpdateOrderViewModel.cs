using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace TravelAgencyFirstShot.Core
{
    public class UpdateOrderViewModel : BaseActionViewModel
    {
        #region Public properites

        /// <summary>
        /// List of columns available to update
        /// </summary>
        public List<string> Columns { get; set; } = DatabaseModel.OrdersInstance.ColumnsToSet;

        /// <summary>
        /// List of clients available to update
        /// </summary>
        public List<string> Orders { get; set; } = DatabaseModel.OrdersInstance.OrdersNamesWithId;

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
        public string SelectedOrder { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateOrderViewModel() : base()
        {
            ActionButtonContent = "Update order";

            SelectedOrder = Orders[0];
            SelectedColumn = Columns[0];
        }

        #endregion

        #region Protected methods
        protected override bool CallAction()
        {
            return DatabaseModel.ClientsInstance.UpdateClient(SelectedColumn, SelectedOrder, Value);           
        }

        #endregion
    }
}
