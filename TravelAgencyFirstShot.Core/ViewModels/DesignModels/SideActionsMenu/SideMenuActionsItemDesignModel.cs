namespace TravelAgencyFirstShot.Core
{
    public class SideMenuActionsItemDesignModel : SideMenuActionsItemViewModel
    {
        public static SideMenuItemDesignModel Instance => new SideMenuItemDesignModel();

        public SideMenuActionsItemDesignModel()
        {
            Content = "Add client";
            AsignedAction = ApplicationActions.AddClient;
        }
    }
}
