using System.Reflection;
using System.Text;

using UnityEngine;

namespace VentilGames
{
    public class GameData<T>
    {
        private string DiskJSONData
        {
            get
            {
                return EncryptDecrypt(PlayerPrefs.GetString(GetType().Name, EncryptDecrypt(JsonUtility.ToJson(this))));
            }
            set
            {
                PlayerPrefs.SetString(GetType().Name, EncryptDecrypt(value));
            }
        }

        private const int FNV1AOffset = unchecked((int)2166136261);
        private const int FNV1APrime = 16777619;

        private int GetTypeHash()
        {
            int hash = FNV1AOffset;
            string typeName = GetType().Name;

            for (int i = 0; i < typeName.Length; i++)
            {
                hash ^= typeName[i];
                hash *= FNV1APrime;
            }

            return hash;
        }

        private string EncryptDecrypt(string data)
        {
            StringBuilder builder = new StringBuilder(data);

            int key = GetTypeHash() & 0x000000FF;

            for (int i = 0; i < builder.Length; i++)
            {
                builder[i] = (char)((int)builder[i] ^ key);
            }

            return builder.ToString();
        }

        public void Save()
        {
            DiskJSONData = JsonUtility.ToJson(this);
        }

        public void Load()
        {
            T instanceData = JsonUtility.FromJson<T>(DiskJSONData);
            foreach(FieldInfo fieldInfo in GetType().GetFields())
            {
                fieldInfo.SetValue(this, fieldInfo.GetValue(instanceData));
            }
        }
    }
}
