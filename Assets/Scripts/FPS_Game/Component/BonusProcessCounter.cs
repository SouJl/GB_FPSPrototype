using System;
using System.Collections;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class BonusProcessCounter : MonoBehaviour
    {
        public static BonusProcessCounter Instance;

        public Action<bool> DoneCallBack;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
        }

        public void AddBonus(BonusModel bonus)
        {
            StartCoroutine(WaitBonusDelay(bonus.ActiveTime, DoneCallBack));
        }

        IEnumerator WaitBonusDelay(float time, Action<bool> doneCallBack)
        {
            yield return new WaitForSeconds(time);
            doneCallBack?.Invoke(true);
        }
    }
}

