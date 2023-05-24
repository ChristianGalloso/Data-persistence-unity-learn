using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int HighScore;
    public int NumberTries;
    public bool IsGameOver = false;


    // Start is called before the first frame update
    void Awake()
    {
      if (Instance !=null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    [Serializable]
    class DataToSave
    {
        public int HighScore;
        public int NumberTries=0;
    }
    public void SaveData()
    {
        DataToSave data = new DataToSave();
        data.HighScore = HighScore;
        data.NumberTries = NumberTries;
        string dataInJSON=JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath+"/savefile.json", dataInJSON);
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string dataInJSON=File.ReadAllText(path);
            DataToSave data = JsonUtility.FromJson<DataToSave>(dataInJSON);
            HighScore= data.HighScore;
            NumberTries= data.NumberTries;
        }
    }
}
