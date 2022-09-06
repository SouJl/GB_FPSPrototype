using UnityEngine;

namespace FPS_Game.MVC
{
    public abstract class BaseView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Collider _collider;

        public Transform Transform { get => _transform; set => _transform = value; }
        public Collider Collider { get => _collider; set => _collider = value; }

        protected virtual void Awake()
        {
            if(TryGetComponent(out Transform transform))
            {
                Transform = transform;
            }
            else
            {
                Debug.Log($"{this} - Не задан компонент Transform!");
            }

            if (TryGetComponent(out Collider collider))
            {
                Collider = collider;
            }
            else
            {
                Debug.Log($"{this} - Не задан компонент Collider!");
            }
        }
    }
}
