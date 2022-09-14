using UnityEngine;

namespace FPS_Game.Data
{
    [System.Serializable]
    public class SpriteData
    {
        public int Width;
        public int Height;
        public byte[] Bytes;

        public SpriteData() { }

        private SpriteData(int width, int height, byte[] bytes)
        {
            Width = width;
            Height = height;
            Bytes = bytes;
        }

        public static implicit operator Sprite(SpriteData data)
        {
            Texture2D tex = new Texture2D(data.Width, data.Height);
            ImageConversion.LoadImage(tex, data.Bytes);
            return Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), Vector2.one);
        }

        public static implicit operator SpriteData(Sprite sprite)
        {
            Texture2D tex = sprite.texture.DeCompress();
            return new SpriteData(tex.width, tex.height, tex.EncodeToPNG());
        }
    }
}
