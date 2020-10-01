using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace TravelAgency.Core
{
    /// <summary>
    /// Representation of the MySql stored procedure parameter
    /// </summary>
    public class Parameter
    {
        #region Public properties

        /// <summary>
        /// Name of the parameter
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the parameter
        /// </summary>
        public object Value { get; set; }

        #endregion
    }
}
