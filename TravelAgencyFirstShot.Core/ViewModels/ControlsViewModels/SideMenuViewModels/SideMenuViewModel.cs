﻿using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace TravelAgencyFirstShot.Core
{
    /// <summary>
    /// ViewModel for SideMenu
    /// </summary>
    public class SideMenuViewModel : BaseViewModel
    {
        #region Public properties

        public List<SideMenuItemViewModel> Items { get; set; }

        #endregion
    }
}
