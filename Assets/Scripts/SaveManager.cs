using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class SaveData
{
    public int[] stageHighScore;
}

public class SaveManager : MonoBehaviour
{
    private string filePath;
    private SaveData highScoreData;
    private int highScore;
    private int stageNum;

    void Start()
    {
        filePath = "/savedata.json";
    }


    public void Save(int stageID)
    {
        StreamReader reader = new StreamReader(Application.persistentDataPath + filePath);
        string inputString = reader.ReadToEnd();
        reader.Close();

        highScoreData = new SaveData();
        highScoreData = JsonUtility.FromJson<SaveData>(inputString);

        int prevHighScore = highScoreData.stageHighScore[stageID];
        int nowHighScore = 0;

        if(prevHighScore < nowHighScore)
        {
            StreamWriter writer = new StreamWriter(Application.persistentDataPath + filePath);
            highScoreData.stageHighScore[stageID] = nowHighScore;
            string jsonstr = JsonUtility.ToJson(highScoreData);

            writer.Write(jsonstr);
            writer.Flush();
            writer.Close();
        }
    }

    public void CreateSaveFile()
    {

    }
}
