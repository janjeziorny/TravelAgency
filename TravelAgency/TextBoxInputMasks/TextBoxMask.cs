using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    /// <summary>
    /// Available masks for <see cref="MaskedTextBox"/>
    /// </summary>
    public enum TextBoxMask
    {
        /// <summary>
        /// Date mask
        /// </summary>
        ZIPcode,

        /// <summary>
        /// Phone number mask
        /// </summary>
        Phone,

        /// <summary>
        /// Price number mask
        /// </summary>
        Price
    }
}
