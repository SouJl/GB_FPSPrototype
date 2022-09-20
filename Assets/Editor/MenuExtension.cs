using UnityEditor;

namespace FPS_Game
{
    public class MenuExtension
    {
        [MenuItem("Tools/FPS_Game/FPS_Game Window")]
        public static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(FPS_GameWindow), false, "FPS_Game");
        }
    }
}

