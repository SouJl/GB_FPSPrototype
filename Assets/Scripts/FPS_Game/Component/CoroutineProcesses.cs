using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

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

        public T SpawnObject<T>(T obj, Vector3 pos) where T : Object
        {
            return Instantiate(obj, pos, Quaternion.identity);
        }

        public void WaitDelayCallBack(float time, Action<bool> doneCallBack)
        {
            StartCoroutine(WaitDelayCoroutine(time, doneCallBack));
        }
        
        public void OnTriggerCallBack(float time, bool state, Action<bool> doneCallBack)
        {
            StartCoroutine(OnTriggerCoroutine(time, state, doneCallBack));
        }

        public void WaitTrailDone(TrailRenderer trail, RaycastHit hit, ParticleSystem onHitSysem) 
        {
            if(trail && onHitSysem)
                StartCoroutine(WaitTrailDoneCoroutine(trail, hit, onHitSysem));
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

        IEnumerator WaitTrailDoneCoroutine(TrailRenderer trail, RaycastHit hit, ParticleSystem onHitSysem)
        {
            float time = 0;
            var startPos = trail.transform.position;
            while(time < 1)
            {
                trail.transform.position = Vector3.Lerp(startPos, hit.point, time);
                time += Time.deltaTime/trail.time;
                yield return null;
            }
            trail.transform.position = hit.point;
            /*Instantiate(onHitSysem, hit.point, Quaternion.LookRotation(hit.normal));*/

            Destroy(trail.gameObject, trail.time);
        }
    }
}

