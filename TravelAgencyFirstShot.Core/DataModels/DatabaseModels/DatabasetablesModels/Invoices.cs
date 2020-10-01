using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Documents;

namespace TravelAgencyFirstShot.Core
{
    /// <summary>
    /// Invoices table model
    /// </summary>
    public class Invoices : BaseDatabasetable
    {
        #region Private Members

        /// <summary>
        /// Views available for this table
        /// </summary>
        private enum InvoicesViews
        {
            invoicedata = 0
        }

        /// <summary>
        /// Contents data of company that are needed to issue the invoice
        /// </summary>
        private DataTable mInvoiceData => DatabaseOperationHelpers.GetTable(new MySqlConnection(Connection.ToString()), DatabaseOperationHelpers.TableCallerBuilder(InvoicesViews.invoicedata.ToString()));

        #endregion

        #region Public Properties

        /// <summary>
        /// Returns invoices IDs combined with their clients
        /// </summary>
        public List<string> InvoicesWithId => DatabasetablesHelpers.CombineIdWithName(GetId(), Table.AsEnumerable().Select(r => r.Field<string>(3)).ToList());

        /// <summary>
        /// Contents data of current invoice
        /// </summary>
        public List<string> CurrentInvoice { get; set; } = new List<string>();

        /// <summary>
        /// Contents data of company that are needed to issue the invoice
        /// </summary>
        public List<string> InvoiceData { get; set; } = new List<string>();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="connection">Connection</param>
        public Invoices(MySqlConnectionStringBuilder connection) : base(connection)
        {
            Name = ApplicationTable.Invoices;
            GetTable();
            GetInvoiceData();
        }

        #endregion

        #region Public operations

        /// <summary>
        /// Updates <see cref="CurrentInvoice"/> property
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public bool UpdateCurrentInvoice(string invoice)
        {
            CurrentInvoice.Clear();

            foreach (DataRow row in Table.Rows)
            {       
                if (int.Parse(row[0].ToString()) == DatabasetablesHelpers.ConvertNameToInt(invoice))
                {
                    for(int i = 0; i < Table.Columns.Count; i++)
                    {
                        if(i == 4 || i == 5)
                        {
                            string date = row[i].ToString();
                            string date2 = "";

                            for(int k = 0; date[k] != ' '; k++)
                            {
                                date2 += date[k];
                            }

                            CurrentInvoice.Add(date2);
                            continue;
                        }

                        CurrentInvoice.Add(row[i].ToString());
                    }

                    break;
                }                    
            }

            return true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Converts <see cref="mInvoiceData"/> to list of string
        /// </summary>
        private void GetInvoiceData()
        {            
            for (int i = 0; i < mInvoiceData.Columns.Count; i++)
            {
                InvoiceData.Add(mInvoiceData.Rows[0][i].ToString());
            }            
        }

        #endregion
    }
}
