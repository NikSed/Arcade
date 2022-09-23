using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public static class SaveManager
{
    private static string path = Application.persistentDataPath + "Saves.json";

    public static void Save<T>(T saveData)
    {
        string jsonDataString = JsonConvert.SerializeObject(saveData);
        File.WriteAllText(path, jsonDataString);
    }

    public static T Load<T>() where T : new()
    {
        if (File.Exists(path))
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

        return new T();
    }
}
