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

    void Start()
    {
        score = 0;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void AddPoint()
    {
        score += addPoint;
    }
}
