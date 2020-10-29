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
    /// Interaction logic for GenderControl.xaml
    /// </summary>
    public partial class GenderControl : UserControl
    {       
        #region Constructor

        public GenderControl()
        {
            InitializeComponent();
            maleRadioButton.IsChecked = true;
            IsMale = true;
            maleRadioButton.Checked += MaleRadioButton_Checked;
            maleRadioButton.Unchecked += MaleRadioButton_Unchecked;
        }

        #endregion

        #region Dependncy Properties

        /// <summary>
        /// Selected gender
        /// </summary>
        public bool IsMale
        {
            get => (bool)GetValue(IsMaleProperty);
            set => SetValue(IsMaleProperty, value);
        }

        /// <summary>
        /// Registers <see cref="IsMaleProperty"/> a dependency property
        /// </summary>
        public static readonly DependencyProperty IsMaleProperty =
            DependencyProperty.Register(nameof(IsMale), typeof(object), typeof(GenderControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        #endregion

        #region Private Events

        /// <summary>
        /// Invoked when the maleRadioButton is checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MaleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            IsMale = true;
            OnIsMaleChanged(sender, e as SelectionChangedEventArgs);
        }

        /// <summary>
        /// Invoked when the maleRadioButton is unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaleRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            IsMale = false;
            OnIsMaleChanged(sender, e as SelectionChangedEventArgs);
        }

        /// <summary>
        /// IsMaleChanged event handler
        /// </summary>
        public event SelectionChangedEventHandler IsMaleChanged;

        /// <summary>
        /// Invoke <see cref="IsMaleChanged"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnIsMaleChanged(object sender, SelectionChangedEventArgs e)
        {
            IsMaleChanged?.Invoke(sender, e);
        }

        #endregion
    }
}
