using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public static class SaveSystem
{
    private static readonly string path = Application.persistentDataPath + "Saves.json";

    public static void Save()
    {
        string jsonDataString = JsonConvert.SerializeObject(CreateSaveData());
        File.WriteAllText(path, jsonDataString);
    }

    public static T Load<T>()
    {
        if (File.Exists(path))
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

        return default;
    }

    private static SaveData CreateSaveData()
    {
        SaveData data = Load<SaveData>();

        List<int> list = new List<int>();

        if (data != null)
        {
            foreach (var score in data.Scores)
            {
                list.Add(score);
            }
        }

        list.Add(ScoreText.Score);

        SaveData saveData = new SaveData();

        foreach (var item in list)
        {
            saveData.Scores.Add(item);
        }

        return saveData;
    }
}