using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ゲームの進行管理や全体的なパラメーターを保持する
public class GameManager : MonoBehaviour
{
    //プレイヤーのスコア
    private int score;
    private Text scoreText;
    //加算するポイント
    private int addPoint = 1;

    //制限時間
    private float limitTime = 60;
    private Text timeText;   

    void Start()
    {
        score = 0;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        timeText  = GameObject.Find("Time").GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = score.ToString();
        if(0 < limitTime)
        {
            limitTime -= Time.deltaTime;
            timeText.text = limitTime.ToString("F0");
        }
        
    }

    public void AddPoint()
    {
        score += addPoint;
    }
}
