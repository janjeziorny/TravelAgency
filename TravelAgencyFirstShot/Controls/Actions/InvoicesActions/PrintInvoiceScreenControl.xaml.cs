using System.Windows.Controls;
using TravelAgencyFirstShot.Core;

namespace TravelAgencyFirstShot
{
    /// <summary>
    /// Interaction logic for UpdateClient.xaml
    /// </summary>
    public partial class PrintInvoiceScreenControl : BaseUserControl<PrintInvoiceScreenViewModel>
    {
        public PrintInvoiceScreenControl()
        {
            InitializeComponent();
        }

        private void PrintClick(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;

                PrintDialog printDialog = new PrintDialog();
                if(printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "Invoice");
                }

            }
            finally
            {
                IsEnabled = true;
            }
        }
    }
}
