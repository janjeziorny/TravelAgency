using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyFirstShot.Core
{
    /// <summary>
    /// Information about result of operation on datebase
    /// </summary>
    public enum DatabaseFeebackState
    {
        /// <summary>
        /// Waiting state
        /// </summary>
        Waiting = 0,

        /// <summary>
        /// Success state
        /// </summary>
        Success = 1,

        /// <summary>
        /// Fail state
        /// </summary>
        Fail = 2
    }
}
