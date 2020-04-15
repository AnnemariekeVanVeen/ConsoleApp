using ConsoleApp.models.menuItems;

namespace ConsoleApp.models
{
    internal interface IMenuItem
    {
        /// <summary>
        /// Getter and setter of title for the menu item
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Handle a action
        /// </summary>
        /// <returns></returns>
        ItemReturn Handle();
    }
}
