namespace FPS_Game.Data
{
    [System.Serializable]
    public class SaveObjectData
    {
        public string Name;
        public Vector3Data position;
        public QuaternionData rotation;
        public bool IsEnable;
    }
}
