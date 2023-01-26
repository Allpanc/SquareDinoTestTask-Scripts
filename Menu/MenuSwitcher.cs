using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SquareDinoTestTask.Menu
{
    public class MenuSwitcher : MonoBehaviour
    {
        private List<MenuDisplay> _menus;

        private void Start()
        {
            _menus = GetComponentsInChildren<MenuDisplay>().ToList();
        }

        public void ShowMainMenu()
        {
            ShowMenu(MenuType.Main);
        }

        public void ShowLocationMenu()
        {
            ShowMenu(MenuType.Location);
        }

        public void ShowLevelMenu()
        {
            ShowMenu(MenuType.Level);
        }

        private void ShowMenu(MenuType menuType)
        {
            _menus.ForEach(x => x.HideContent());
            MenuDisplay menu = _menus.Find(x => x.MenuType == menuType);
            menu.ShowContent();
        }
    }
}
