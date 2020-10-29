using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for FrameWithValue.xaml
    /// </summary>
    public partial class FrameWithValue : UserControl
    {
        #region Constructor

        public FrameWithValue()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Properties

        /// <summary>
        /// The current column to show in FrameWithValue
        /// </summary>
        public FrameworkElement CurrentColumn
        {
            get => (FrameworkElement)GetValue(CurrentColumnProperty);
            set => SetValue(CurrentColumnProperty, value);
        }

        /// <summary>
        /// Value of the <see cref="CurrentColumn"/> control
        /// </summary>
        public object Value
        {
            //get => (string)GetValue(ValueProperty);
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        /// <summary>
        /// Registers <see cref="CurrentColumn"/> a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentColumnProperty =
            DependencyProperty.Register(nameof(CurrentColumn), typeof(FrameworkElement), typeof(FrameWithValue), new UIPropertyMetadata(CurrentColumnPropertyChanged));

        /// <summary>
        /// Registers <see cref="Value"/> a dependency property
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(object), typeof(FrameWithValue), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        #endregion


        #region Property Changed Events

        /// <summary>
        /// Called when the <see cref="PropertyChanged"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void CurrentColumnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Representation of columnFrame elemnt
            var frame = (d as FrameWithValue).columnFrame;
            
            // Set the content of the frame
            var value = frame.Content = (d as FrameWithValue).CurrentColumn;

            // Get Type of the CurrentColumn
            Type valueType = value.GetType();
            
            // MaskedTextBox Type
            if (valueType == typeof(MaskedTextBox))
            {
                // Consider CurrentColumn DependencyProperty as MaskedTextBox
                var o = (d as FrameWithValue).CurrentColumn as MaskedTextBox;

                // Attach the TextChanged event
                o.TextChanged += new TextChangedEventHandler((d as FrameWithValue).TextBox_TextChanged);

                // Remove the value from the Value
                (d as FrameWithValue).Value = new object();
            }
            // TextBox Type
            else if (valueType == typeof(TextBox))
            {
                // Remove the value from the Value
                (d as FrameWithValue).Value = new object();

                // Consider CurrentColumn DependencyProperty as TextBox
                var o = (d as FrameWithValue).CurrentColumn as TextBox;

                // Attach the TextChanged event
                o.TextChanged += new TextChangedEventHandler((d as FrameWithValue).TextBox_TextChanged);                
            }
            // Calendar Type
            else if (valueType == typeof(Calendar))
            {
                // Remove the value from the Value
                var v = (d as FrameWithValue).Value = new object();

                // Consider CurrentColumn DependencyProperty as Calendar
                var o = (d as FrameWithValue).CurrentColumn as Calendar;

                // Attach the TextChanged event
                o.DateChanged += (d as FrameWithValue).Date_DateChanged;
                (d as FrameWithValue).Value = (o.DataContext as CalendarViewModel).ToString();
            }
            // GenderControl Type
            else if (valueType == typeof(GenderControl))
            {
                // Remove the value from the Value
                (d as FrameWithValue).Value = true;

                // Consider CurrentColumn DependencyProperty as GenderControl
                var o = ((d as FrameWithValue).CurrentColumn as GenderControl);

                // Attach the SelectionChanged event
                o.IsMaleChanged += ((d as FrameWithValue).Gender_GenderChanged);
            }
            else if(valueType == typeof(ComboBox))
            {
                // Remove the value from the Value
                (d as FrameWithValue).Value = "";

                // Consider CurrentColumn DependencyProperty as ComboBox
                var o = ((d as FrameWithValue).CurrentColumn as ComboBox);

                // Attach the SelectionChanged event
                o.SelectionChanged += ((d as FrameWithValue).ComboBox_SelectionChanged);
            }
        }

        #endregion

        #region Private Event Handlers

        /// <summary>
        /// Invoked when the Text property has been changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var t = sender as TextBox;
            Value = t.Text;
        }

        /// <summary>
        /// Invoked when the IsChecked property has been changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gender_GenderChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = sender as RadioButton;
            Value = t.IsChecked;
        }

        /// <summary>
        /// Invoked when the IsChecked property has been changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = sender as ComboBox;
            Value = t.SelectedItem.ToString();
        }

        /// <summary>
        /// Invoked when the IsChecked property has been changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Date_DateChanged(object sender, string e)
        {
            Value = e;
        }

        #endregion        
    }
}
