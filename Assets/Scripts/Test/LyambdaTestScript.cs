using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LyambdaTestScript : MonoBehaviour
{

    Dictionary<string, int> dict = new Dictionary<string, int>()
    {
        {"four",4},
        {"two", 2},
        {"one", 1},
        {"three", 3},
    };

    void Start()
    {
        //example solution
        /*var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
        foreach (var pair in d)
        {
            Debug.Log($"{pair.Key} - {pair.Value}");
        }*/

        var expandDictOdrder = new Dictionary<string, int>(dict);
        var shortDictOdrder = new Dictionary<string, int>(dict);
       
        Debug.Log("Развернутое обращение к OrderBy:");
        foreach(var pair in expandDictOdrder.OrderBy(GetPairValue).ToArray()) 
        {
            Debug.Log($"{pair.Key} - {pair.Value}");
        }
        Debug.Log("Свернутое обращение к OrderBy через лямбду:");
        foreach (var pair in shortDictOdrder.OrderBy(d => d.Value).ToArray())
        {
            Debug.Log($"{pair.Key} - {pair.Value}");
        }
    }

    private int GetPairValue(KeyValuePair<string, int> pair) => pair.Value;
}
