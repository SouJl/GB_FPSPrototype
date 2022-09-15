using UnityEngine;

namespace FPS_Game.Data
{
    [System.Serializable]
    public class QuaternionData
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public QuaternionData() { }

        private QuaternionData(float xData, float yData, float zData, float wData)
        {
            X = xData;
            Y = yData;
            Z = zData;
            W = wData;
        }


        public static implicit operator Quaternion(QuaternionData data) => new Quaternion(data.X, data.Y, data.Z, data.W);
        public static implicit operator QuaternionData(Quaternion quat) => new QuaternionData(quat.x, quat.y, quat.z, quat.w);
    }
}
