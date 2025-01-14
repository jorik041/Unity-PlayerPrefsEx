using System;
using UnityEngine;

namespace Extensions.Unity.PlayerPrefsEx
{
    public class PlayerPrefsFloat
    {
        public string Key { get; private set; }
        public string EncryptedKey { get; private set; }
        public float DefaultValue { get; private set; }
        public float Value
        {
            get => PlayerPrefsEx.GetEncryptedFloat(EncryptedKey, DefaultValue);
            set => PlayerPrefsEx.SetEncryptedFloat(EncryptedKey, value);
        }

        public PlayerPrefsFloat(string key, float defaultValue = default)
        {
            this.Key = key;
            this.EncryptedKey = key.EncryptKey<float>();
            this.DefaultValue = defaultValue;
        }
    }
    public static partial class PlayerPrefsEx
    {
        public static float GetFloat(string key, float defaultValue = default) => GetEncryptedFloat(key.EncryptKey<float>(), defaultValue);
        public static void SetFloat(string key, float value) => SetEncryptedFloat(key.EncryptKey<float>(), value);
        internal static float GetEncryptedFloat(string encryptedKey, float defaultValue = default) => PlayerPrefs.GetFloat(encryptedKey, defaultValue);
        internal static void SetEncryptedFloat(string encryptedKey, float value) => PlayerPrefs.SetFloat(encryptedKey, value);
    }
}