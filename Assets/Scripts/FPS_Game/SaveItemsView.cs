using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

#if UNITY_EDITOR
namespace FPS_Game
{
    public class SaveItemsView : MonoBehaviour
    {
        [Header("To Save")]
        public List<Transform> itemsPos = new List<Transform>();

        [Space(30)]
        [Header("Path Settings")]
        public string directoryName;
        public string sceneName;

        private string _savePath;

        public string SavePath { get => _savePath; set => _savePath = value; }

        private void OnDrawGizmos()
        {
            sceneName = EditorSceneManager.GetActiveScene().name;
            directoryName = "Items Data";
            
            SavePath = Path.Combine(Application.dataPath, directoryName, $"ItemsData_{sceneName}.xml");
        }
    }
}
#endif

