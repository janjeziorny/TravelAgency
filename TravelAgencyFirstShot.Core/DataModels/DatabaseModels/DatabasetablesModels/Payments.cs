using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TravelAgencyFirstShot.Core
{
    /// <summary>
    /// Payments table model
    /// </summary>
    public class Payments : BaseDatabasetable
    {
        #region Private Members

        /// <summary>
        /// Views available for <see cref="Payments" table/>
        /// </summary>
        private enum PaymentsViews
        {
            paymentmethods = 0,
            clientsnames = 1
        }

        private DataTable PaymentMethods { get; set; }

        /// <summary>
        /// List of payments methods
        /// </summary>
        private List<string> PaymentMethodsNames { get; set; }

        /// <summary>
        /// List of payments methods IDs
        /// </summary>
        private List<int> PaymentMethodsIds { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Returns payment methods combines with their names
        /// </summary>
        public List<string> PaymentMethodsWithId => DatabasetablesHelpers.CombineIdWithName(PaymentMethodsIds, PaymentMethodsNames);

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="connection">Connection</param>
        public Payments(MySqlConnectionStringBuilder connection) : base(connection)
        {
            Name = ApplicationTable.Payments;
            GetTable();
        }

        #endregion

        #region Public Operations

        /// <summary>
        /// Add client function
        /// </summary>
        /// <param name="bookedplaces">Number of booked places</param>
        /// <param name="clientid">ID of client</param>
        /// <param name="tripid">ID of trip</param>
        /// <returns></returns>
        public bool AddPayment(string invoiceid, double amount, string paymentMethod)
        {
            return CallStoredProcedure(TravelAgencyStoredProcedures.spAddPayment,

                new List<Parameter>{
                new Parameter { Name = spAddPaymentParameters.pInvoice_id.ToString(), Value = DatabasetablesHelpers.ConvertNameToInt(invoiceid) },
                new Parameter { Name = spAddPaymentParameters.pAmount.ToString(), Value = amount },
                new Parameter { Name = spAddPaymentParameters.pPayment_method.ToString(), Value = DatabasetablesHelpers.ConvertNameToInt(paymentMethod) }
            });
        }
        #endregion

        #region Private members

        /// <summary>
        /// Loads data into the <see cref="PaymentMethods"/>
        /// </summary>
        private void GetPaymentMethods()
        {
            PaymentMethods = DatabaseOperationHelpers.GetTable(new MySqlConnection(Connection.ToString()),
            DatabaseOperationHelpers.TableCallerBuilder(PaymentsViews.paymentmethods.ToString()));
        }

        public List<string> GetPaymentMethodsWithId()
        {            
            GetPaymentMethods();

            PaymentMethodsNames = PaymentMethods.AsEnumerable().Select(r => r.Field<string>(1)).ToList();
            PaymentMethodsIds = PaymentMethods.AsEnumerable().Select(r => r.Field<int>(0)).ToList();

            return DatabasetablesHelpers.CombineIdWithName(PaymentMethodsIds, PaymentMethodsNames);
        }

        #endregion
    }
}
