using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    [SerializeField] GameObject molePrefab;
    private int stageNum = 10;

    public int GetStageNum()
    {
        return stageNum;
    }

    
    //TODO: モグラの配置
    public void CreateStage()
    {

    }

}
