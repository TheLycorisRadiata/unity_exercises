using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color TeamColor;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    [System.Serializable]
    private class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        string json;
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;
        json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        string json;
        SaveData data;
        if (File.Exists(path))
        {
            json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);
            TeamColor = data.TeamColor;
        }
    }
}
