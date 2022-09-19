using System;
using UnityEngine;

namespace FPS_Game.Data
{
    [System.Serializable]
    public class Vector3Data
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3Data() { }

        private Vector3Data(float xValue, float yValue, float zValue)
        {
            X = xValue;
            Y = yValue;
            Z = zValue;
        }

        public static implicit operator Vector3(Vector3Data vectorValue) => new Vector3(vectorValue.X, vectorValue.Y, vectorValue.Z);

        public static implicit operator Vector3Data(Vector3 vectorValue) => new Vector3Data(vectorValue.x, vectorValue.y, vectorValue.z);
        
        public override string ToString()
        {
            return $"[{X},{Y},{Z}]";
        }
    }
}
