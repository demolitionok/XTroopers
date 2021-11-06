using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSaver
{
    private readonly string _savePath;

    public JsonSaver()
    {
        _savePath = Application.persistentDataPath + "/Save.json";
    }

    public void Save(SaveData data)
    {
        var json = JsonUtility.ToJson(data);
        using (var writer = new StreamWriter(_savePath))
        {
            writer.WriteLine(json);
        }
    }

    public SaveData Load()
    {
        string json = "";
        using (var reader = new StreamReader(_savePath))
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                line = reader.ReadLine();
                json += line;
            }
        }

        if (string.IsNullOrEmpty(json))
        {
            return new SaveData();
        }

        return JsonUtility.FromJson<SaveData>(json);
    }
}
