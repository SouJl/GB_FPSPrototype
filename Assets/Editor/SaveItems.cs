using FPS_Game.Data;
using FPS_Game.MVC;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

namespace FPS_Game
{
    [CustomEditor(typeof(SaveItemsView))]
    public class SaveItems : Editor
    {
        private ToSerializeXMLData<List<Vector3Data>> _xMLData;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            SaveItemsView saveItems = (SaveItemsView)target;

            _xMLData = new ToSerializeXMLData<List<Vector3Data>>(saveItems.SavePath);

            if (GUILayout.Button("Save"))
            {
                
                if (saveItems.itemsPos.Count > 0)
                {
                    var resultData = new List<Vector3Data>(); 
                    foreach(var pos in saveItems.itemsPos.Select(p => p.position).ToList())
                    {
                        resultData.Add(pos);
                    }
                    _xMLData.Save(resultData);
                }
            }

            if (GUILayout.Button("Load"))
            {
                if (File.Exists(saveItems.SavePath))
                {
                    var loadData = _xMLData.Load();
                    if(loadData.Count == saveItems.itemsPos.Count) 
                    {
                        bool isPosChanged = false;
                        for(int i =0; i < loadData.Count; i++)
                        {
                            if (!saveItems.itemsPos[i].position.Equals(loadData[i]))
                            {
                                saveItems.itemsPos[i].position = loadData[i];
                                isPosChanged = true;
                            }                           
                        }
                        if(isPosChanged)
                            Debug.Log("Для одного или нескольких объектов было изменено положение");
                    }
                    else
                    {
                        Debug.LogError("Колличество загруженных элементов не равно целевым!");
                    }                   
                }
            }

        }
    }
}

