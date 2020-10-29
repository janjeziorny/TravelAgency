using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Core
{
    /// <summary>
    /// Bsae ViewModel for each UpdateControl
    /// </summary>
    public abstract class BaseUpdateViewModel : BaseActionViewModel
    {
        #region Private Members

        protected string selectedColumn;

        #endregion

        #region Public Properites

        public ApplicationTable Table { get; set; }

        /// <summary>
        /// List of columns available to update
        /// </summary>
        public List<string> ColumnsNames { get; set; }

        /// <summary>
        /// List of elements available to update
        /// </summary>
        public List<string> Values { get; set; }

        /// <summary>
        /// Value of updated column
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Selected column
        /// </summary>
        public string SelectedColumn
        {
            get
            {
                return selectedColumn;
            }

            set
            {
                selectedColumn = value;
            }
        }

        /// <summary>
        /// Selected client
        /// </summary>
        public string SelectedValue
        {
            get; set;
        }

        public object Parameter => GetParameter();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseUpdateViewModel() : base()
        {
            ActionButtonContent = "Update";
        }

        #endregion

        protected virtual object GetParameter() { return new object(); }
    }
}
