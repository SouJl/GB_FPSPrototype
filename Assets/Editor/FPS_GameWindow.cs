using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FPS_Game
{
    public class FPS_GameWindow : EditorWindow
    {
        public List<GameObject> AvailablePrefabs;
        public static GameObject ObjectInstantiate;

        public string _nameObject = "Hello World";
        public bool _groupEnabled;
        public bool _randomColor = true;
        public int _countObject = 1;
        public float _radius = 10;

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
            GUILayout.Label("������� ���������", EditorStyles.boldLabel);
            
            EditorGUILayout.PropertyField(gameObjectProp, true);

            ObjectInstantiate = EditorGUILayout.ObjectField("������ ������� ����� ��������", ObjectInstantiate, typeof(GameObject), true) as GameObject;
            _nameObject = EditorGUILayout.TextField("��� �������", _nameObject);
            _groupEnabled = EditorGUILayout.BeginToggleGroup("�������������� ���������", _groupEnabled);
            _randomColor = EditorGUILayout.Toggle("��������� ����", _randomColor);
            _countObject = EditorGUILayout.IntSlider("���������� ��������", _countObject, 1, 100);
            _radius = EditorGUILayout.Slider("������ ����������", _radius, 10, 50);
            
            EditorGUILayout.EndToggleGroup();
            
            var button = GUILayout.Button("������� �������");
            if (button)
            {
                if (ObjectInstantiate)
                {
                    GameObject root = new GameObject("Root");
                    for (int i = 0; i < _countObject; i++)
                    {
                        float angle = i * Mathf.PI * 2 / _countObject;
                        Vector3 pos = new Vector3(Mathf.Cos(angle), 0,
                        Mathf.Sin(angle)) * _radius;
                        GameObject temp = Instantiate(ObjectInstantiate, pos,
                        Quaternion.identity);
                        temp.name = _nameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                        var tempRenderer = temp.GetComponent<Renderer>();
                        if (tempRenderer && _randomColor)
                        {
                            tempRenderer.material.color = Random.ColorHSV();
                        }
                    }
                }             
            }
        }

    }
}

