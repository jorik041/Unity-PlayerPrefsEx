using UnityEngine;

namespace Extensions.Unity.PlayerPrefsEx
{
    public class PlayerPrefsInt
    {
        public string Key { get; private set; }
        public string EncryptedKey { get; private set; }
        public int DefaultValue { get; private set; }
        public int Value
        {
            get => PlayerPrefsEx.GetEncryptedInt(EncryptedKey, DefaultValue);
            set => PlayerPrefsEx.SetEncryptedInt(EncryptedKey, value);
        }

        public PlayerPrefsInt(string key, int defaultValue = default)
        {
            this.Key = key;
            this.EncryptedKey = key.EncryptKey<int>();
            this.DefaultValue = defaultValue;
        }
    }
    public static partial class PlayerPrefsEx
    {
        public static int GetInt(string key, int defaultValue = default) => GetEncryptedInt(key.EncryptKey<int>(), defaultValue);
        public static void SetInt(string key, int value) => SetEncryptedInt(key.EncryptKey<int>(), value);
        internal static int GetEncryptedInt(string encryptedKey, int defaultValue = default) => PlayerPrefs.GetInt(encryptedKey, defaultValue);
        internal static void SetEncryptedInt(string encryptedKey, int value) => PlayerPrefs.SetInt(encryptedKey, value);
    }
}