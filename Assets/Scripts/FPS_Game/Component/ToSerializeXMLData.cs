using System.IO;
using System.Xml.Serialization;

namespace FPS_Game.MVC
{
    public class ToSerializeXMLData<T> : ISaveData<T>
    {
        private XmlSerializer _dataXMLSerializer;
        private string _filePath;

        public ToSerializeXMLData(string filePath)
        {
            _filePath = filePath;
            _dataXMLSerializer = new XmlSerializer(typeof(T));
        }

        public T Load()
        {
            T result;
            if (!File.Exists(_filePath)) return default;
            using (var fs = new FileStream(_filePath, FileMode.Open))
            {
                result = (T)_dataXMLSerializer.Deserialize(fs);
            }
            return result;
        }

        public void Save(T data)
        {
            if (data == null && !string.IsNullOrEmpty(_filePath)) return;
            using (var fs = new FileStream(_filePath, FileMode.Create))
            {
                _dataXMLSerializer.Serialize(fs, data);
            }
        }
    }
}
