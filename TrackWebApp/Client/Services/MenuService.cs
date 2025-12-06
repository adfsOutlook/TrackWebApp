namespace Project.Client.Services
{

    public interface IMenuService
    {
        bool IsMenuVisible { get; set; }
        event Action<bool> OnMenuVisibilityChange;

        void ToggleMenu(bool isVisible);
    }




    public class MenuService : IMenuService
    {
        public bool IsMenuVisible { get; set; } = false;

        public event Action<bool> OnMenuVisibilityChange;

        public void ToggleMenu(bool isVisible)
        {
            IsMenuVisible = isVisible;
            OnMenuVisibilityChange?.Invoke(IsMenuVisible);
        }
    }





}
