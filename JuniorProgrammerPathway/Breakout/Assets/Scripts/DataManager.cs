using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public int HighScore = 0;
    public float PaddleSpeed = 2.0f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(this);
        LoadDataFromDisk();
    }

    private class SaveData
    {
        public int HighScore;
        public float PaddleSpeed;
    }

    public void LoadDataFromDisk()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        string json;
        SaveData data;
        if (File.Exists(path))
        {
            json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);
            HighScore = data.HighScore;
            PaddleSpeed = data.PaddleSpeed;
        }
    }

    public void SaveDataToDisk()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        string json;
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        data.PaddleSpeed = PaddleSpeed;
        json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }
}
