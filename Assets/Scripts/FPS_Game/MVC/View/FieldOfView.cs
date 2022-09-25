using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class FieldOfView: MonoBehaviour
    {
        [SerializeField] private Transform _pointofView;
        [SerializeField] private float _distance = 100f;
        [Range(0, 360)]
        [SerializeField] private float _angle;
        [SerializeField] private LayerMask _targetMask;
        [SerializeField] private LayerMask _obstructionMask;

        public Transform PointofView { get => _pointofView; set => _pointofView = value; }
        public float Distance { get => _distance; set => _distance = value; }
        public float Angle { get => _angle; set => _angle = value; }
        public LayerMask TargetMask { get => _targetMask; set => _targetMask = value; }
        public LayerMask ObstructionMask { get => _obstructionMask; set => _obstructionMask = value; }
    }
}
