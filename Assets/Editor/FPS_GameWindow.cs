using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FPS_Game
{
    public class FPS_GameWindow : EditorWindow
    {
        [ReadOnly] public List<GameObject> AvailablePrefabs;      
        [ReadOnly] public static GameObject SelectedObjectToInst;
        
        public Vector3 SpawnPosition = Vector3.zero;

        public string NameObject = "";
        public bool IsGroupEnabled;
        public int CountObject = 1;
        public float SpawnRadius = 5;

        private SerializedObject so;
        private SerializedProperty gameObjectProp;

        private void OnEnable()
        {
            string[] foldersToSearch = { @"Assets\Prefabs" };
            AvailablePrefabs = GetAssets<GameObject>(foldersToSearch, "t:prefab");

            so = new SerializedObject(this);
            gameObjectProp = so.FindProperty("AvailablePrefabs");

        }

        public static List<T> GetAssets<T>(string[] _foldersToSearch, string _filter) where T : UnityEngine.Object
        {
            string[] guids = AssetDatabase.FindAssets(_filter, _foldersToSearch);
            List<T> a = new List<T>();
            for (int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a.Add(AssetDatabase.LoadAssetAtPath<T>(path));
            }
            return a;
        }


        private void OnGUI()
        {
            EditorGUILayout.Space(20);

            EditorGUILayout.PropertyField(gameObjectProp, new GUIContent("Available Prefabs in Project"), true);

            SelectedObjectToInst = EditorGUILayout.ObjectField("What Instantiate", SelectedObjectToInst, typeof(GameObject), true) as GameObject;
            NameObject = EditorGUILayout.TextField("Name", NameObject);

            EditorGUILayout.Space(5);
            SpawnPosition = EditorGUILayout.Vector3Field("Spawn Posotion", SpawnPosition);
            EditorGUILayout.Space(5);

            IsGroupEnabled = EditorGUILayout.BeginToggleGroup("Additional Settings", IsGroupEnabled);       
            CountObject = EditorGUILayout.IntSlider("Objects Count", CountObject, 1, 20); 
            SpawnRadius = EditorGUILayout.Slider("Spawn Radius", SpawnRadius, 5, 20);                  
            EditorGUILayout.EndToggleGroup();

            EditorGUILayout.Space(20);

            var button = GUILayout.Button("Create Object");
            if (button)
            {
                if (SelectedObjectToInst)
                {
                    GameObject root = new GameObject("Root");
                    for (int i = 0; i < CountObject; i++)
                    {
                        Vector3 pos = SpawnPosition + Random.insideUnitSphere * SpawnRadius * (IsGroupEnabled ? 1 : 0);
                        GameObject temp = Instantiate(SelectedObjectToInst, pos, Quaternion.identity);
                        temp.name = NameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                    }
                }             
            }
        }

        private void OnSelectionChange()
        {
            var newSelected = Selection.activeGameObject;
            if (newSelected && AvailablePrefabs.Contains(newSelected))
            {
                SelectedObjectToInst = newSelected;
                NameObject = newSelected.name;
                Debug.Log(SelectedObjectToInst.name);
                Repaint();
            }               
        }

    }
}

