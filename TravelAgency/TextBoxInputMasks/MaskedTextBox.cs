using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TravelAgency
{
    public class MaskedTextBox : TextBox
    {
        /// <summary>
        /// The msk of the TextBox
        /// </summary>
        public TextBoxMask Mask { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MaskedTextBox()
        {
            this.TextChanged += new TextChangedEventHandler(MaskedTextBox_TextChanged);
        }

        /// <summary>
        /// Event that handles TextChanged property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.CaretIndex = this.Text.Length;

            var tbEntry = sender as MaskedTextBox;

            if (tbEntry != null && tbEntry.Text.Length > 0)
            {
                if(tbEntry.Mask == TextBoxMask.Phone || tbEntry.Mask == TextBoxMask.ZIPcode)
                {
                    tbEntry.Text = formatNumber(tbEntry.Text, tbEntry.Mask);
                }
                else if(tbEntry.Mask == TextBoxMask.Price)
                {
                    tbEntry.Text = formatPrice(tbEntry.Text);
                }
            }
        }

        public static string formatPrice(string MaskedNum)
        {
            int x;
            bool isDot = false;
            StringBuilder sb = new StringBuilder();

            if(MaskedNum != null)
            {
                for(int i = 0; i < MaskedNum.Length; i++)
                {
                    if(int.TryParse(MaskedNum.Substring(i, 1), out x))
                    {
                        if(isDot)
                        {
                            if (MaskedNum.Substring(MaskedNum.IndexOf(".")).Length <= 3)
                            {
                                sb.Append(x.ToString());
                            }
                            else
                            {
                                sb.Append(MaskedNum.IndexOf("."));
                                sb.Append(MaskedNum.IndexOf(".")+1);
                                return MaskedNum.Substring(0, MaskedNum.Length-1);
                            }                                
                        }
                        else
                            sb.Append(x.ToString());
                    }
                    if(MaskedNum.Substring(i, 1) == "." && isDot == false)
                    {
                        isDot = true;
                        sb.Append(".");
                    }
                }

            }
            return sb.ToString();
        }

        public static string formatNumber(string MaskedNum, TextBoxMask mask)
        {
            int x;
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            if (MaskedNum != null)
            {
                for (int i = 0; i < MaskedNum.Length; i++)
                {
                    if (int.TryParse(MaskedNum.Substring(i, 1), out x))
                    {
                        sb.Append(x.ToString());
                    }
                }

                switch (mask)
                {
                    case TextBoxMask.Phone:
                        return Phone(sb.ToString()).ToString();

                    case TextBoxMask.ZIPcode:
                        return ZIPcode(sb.ToString()).ToString();

                    default:
                        break;
                }

            }
            return sb.ToString();
        }

        private static StringBuilder Phone(string sb)
        {
            StringBuilder sb2 = new StringBuilder();

            if (sb.Length > 0) sb2.Append(sb.Substring(0, 1));
            if (sb.Length > 1) sb2.Append(sb.Substring(1, 1));
            if (sb.Length > 2) sb2.Append(sb.Substring(2, 1));
            if (sb.Length > 3) sb2.Append(sb.Substring(3, 1));
            if (sb.Length > 4) sb2.Append(sb.Substring(4, 1));
            if (sb.Length > 5) sb2.Append(sb.Substring(5, 1));
            if (sb.Length > 6) sb2.Append(sb.Substring(6, 1));
            if (sb.Length > 7) sb2.Append(sb.Substring(7, 1));
            if (sb.Length > 8) sb2.Append(sb.Substring(8, 1));

            return sb2;
        }

        private static StringBuilder ZIPcode(string sb)
        {
            StringBuilder sb2 = new StringBuilder();

            if (sb.Length > 0) sb2.Append(sb.Substring(0, 1));
            if (sb.Length > 1) sb2.Append(sb.Substring(1, 1));

            if (sb.Length > 2) sb2.Append("-");            

            if (sb.Length > 2) sb2.Append(sb.Substring(2, 1));
            if (sb.Length > 3) sb2.Append(sb.Substring(3, 1));
            if (sb.Length > 4) sb2.Append(sb.Substring(4, 1));

            return sb2;
        }
    }
}
