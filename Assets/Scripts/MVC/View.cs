using System;
using UnityEngine;

namespace MVC
{
    public class View : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Collider _collider;
        [SerializeField] private Rigidbody _rb;

        public Transform Transform { get => _transform; set => _transform = value; }
        public Collider Collider { get => _collider; set => _collider = value; }
        public Rigidbody Rb { get => _rb; set => _rb = value; }

        public Action<Collider, int, Transform> OnLevelObjectContact { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            var levelObjectColl = other;
            OnLevelObjectContact?.Invoke(levelObjectColl, 1, Transform);
        }
    }
}
