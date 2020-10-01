using MySql.Data.MySqlClient.X.XDevAPI.Common;
using System.Collections.Generic;

namespace TravelAgencyFirstShot.Core
{
    /// <summary>
    /// Column of <see cref="BaseDatabasetable"/>
    /// </summary>
    public class DatabaseTableColumn
    {
        /// <summary>
        /// Column header
        /// </summary>
        public string ColumnHeader { get; set; }

        /// <summary>
        /// List of values specyfic for this column
        /// </summary>
        public List<object> RowValues { get; set; }

        /// <summary>
        /// Type of this column
        /// </summary>
        public ColumnType ColumnType { get; set; }
    }
}
