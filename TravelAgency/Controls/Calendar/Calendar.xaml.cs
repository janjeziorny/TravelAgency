using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelAgency.Core;

namespace TravelAgency
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : BaseUserControl<CalendarViewModel>
    {
        public event EventHandler<string> DateChanged;

        /// <summary>
        /// Invoke <see cref="DateChanged"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnDateChangedChanged(object sender, string e)
        {
            DateChanged?.Invoke(sender, e);
        }

        #region Constructor

        public Calendar()
        {
            InitializeComponent();

            year.SelectionChanged += DateChange_SelectionChanged;
            month.SelectionChanged += DateChange_SelectionChanged;
            day.SelectionChanged += DateChange_SelectionChanged;
        }        

        #endregion

        #region Dependency Properties

        /// <summary>
        /// 
        /// </summary>
        public string Date
        {
            get => (string)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }

        /// <summary>
        /// Registers <see cref="Date"/> a dependency property
        /// </summary>
        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register(nameof(Date), typeof(string), typeof(Calendar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        #endregion

        #region Private Events

        private void DateChange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Date = (this.DataContext as CalendarViewModel).ToString();
            OnDateChangedChanged(sender, Date);
        }

        #endregion
    }
}
