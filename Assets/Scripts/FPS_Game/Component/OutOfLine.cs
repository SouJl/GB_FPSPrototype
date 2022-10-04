using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class OutOfLine : MonoBehaviour
{
    public Action CallRestart;

    private void Awake()
    {
        var collider = GetComponent<Collider>();
        collider.isTrigger = true; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") 
        {
            CallRestart?.Invoke();
        }
    }
}
