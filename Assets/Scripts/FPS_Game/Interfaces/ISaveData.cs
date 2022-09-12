namespace FPS_Game.MVC
{
    public interface ISaveData<T>
    {
        void Save(T data);

        T Load();
    }
}
