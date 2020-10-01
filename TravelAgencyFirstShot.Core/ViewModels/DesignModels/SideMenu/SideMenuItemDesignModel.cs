namespace TravelAgencyFirstShot.Core
{
    public class SideMenuItemDesignModel : SideMenuItemViewModel
    {
        public static SideMenuItemDesignModel Instance => new SideMenuItemDesignModel();

        public SideMenuItemDesignModel()
        {
            Content = "Clients";
            AsignedTable = ApplicationTable.Clients;
        }
    }
}
