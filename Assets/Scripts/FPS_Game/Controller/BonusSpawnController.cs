using UnityEngine;

namespace FPS_Game 
{
    public class BonusSpawnController : MonoBehaviour
    {
        [Header("Spawn Bonus Parametrs")]
        public Interactable _bonusPrefab;
        public Vector3 center;
        public Vector3 size;
        [Range(1,10)]
        public int spawnCount;

        private void Start()
        {
            for(int i =0; i < spawnCount; i++) 
            {
                Spawn();
            }
        }

        private void Spawn() 
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 
                                                Random.Range(-size.y / 2, size.y / 2), 
                                                Random.Range(-size.y / 2, size.y / 2));

            Instantiate(_bonusPrefab, pos, Quaternion.identity);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawCube(center, size);
        }

    }
}

