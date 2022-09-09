using System;
using System.Collections;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class CoroutineProcesses : MonoBehaviour
    {
        public static CoroutineProcesses Instance;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
        }

        public void WaitDelayCallBack(float time, Action<bool> doneCallBack)
        {
            StartCoroutine(WaitDelayCoroutine(time, doneCallBack));
        }
        
        public void OnTriggerCallBack(float time, bool state, Action<bool> doneCallBack)
        {
            StartCoroutine(OnTriggerCoroutine(time, state, doneCallBack));
        }

        IEnumerator WaitDelayCoroutine(float time, Action<bool> doneCallBack)
        {
            yield return new WaitForSeconds(time);
            doneCallBack?.Invoke(true);
        }

        IEnumerator OnTriggerCoroutine(float time, bool state, Action<bool> doneCallBack)
        {
            if (state)
            {
                yield return new WaitForSeconds(time);
                doneCallBack?.Invoke(true);
            }
            else
            {
                doneCallBack?.Invoke(false);
            }
        }
    }
}

