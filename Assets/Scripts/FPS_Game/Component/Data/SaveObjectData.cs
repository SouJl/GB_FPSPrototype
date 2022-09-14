namespace FPS_Game.Data
{
    [System.Serializable]
    public class SaveObjectData<T>
    {
        public string Name;
        public Vector3Data position;
        public T ObjectData;
        public bool IsEnable;
    }
}
