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
    private GameManager nowScoreData;
    private StageGenerator stageGenerator;
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

        nowScoreData = new GameManager();
        int nowHighScore = nowScoreData.GetScore();
        int prevHighScore = highScoreData.stageHighScore[stageID];
        

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

    public int Load(int stageID)
    {
        //セーブファイルがないとき、新規作成する
        if (!File.Exists(Application.persistentDataPath + filePath)) CreateSaveFile();

        StreamReader reader = new StreamReader (Application.persistentDataPath + filePath);
        string inputString = reader.ReadToEnd();
        reader.Close();
        highScoreData = JsonUtility.FromJson<SaveData>(inputString);

        return highScoreData.stageHighScore[stageID];
    }

    //新規でセーブファイルを作成する
    public void CreateSaveFile()
    {
        StreamWriter writer = File.CreateText(filePath);

        stageGenerator = new StageGenerator();
        stageNum = stageGenerator.GetStageNum();

        highScoreData = new SaveData();
        highScoreData.stageHighScore = new int[stageNum + 1];
        string jsonstr = JsonUtility.ToJson(highScoreData);

        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }
}
