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
    private float limitTime = 10;
    private Text timeText;

    //タイトル用テキスト・パネル
    private Text titleText;
    private GameObject titlePanel;
    
    //ゲームの進行状態
    public enum GameState
    {
        Opening,
        Playing,
        Clear
    }

    //現在のゲーム進行状態
    private GameState currentState = GameState.Opening;


    void Start()
    {
        score = 0;
        scoreText  = GameObject.Find("Score").GetComponent<Text>();
        timeText   = GameObject.Find("Time").GetComponent<Text>();
        titleText  = GameObject.Find("Title").GetComponent<Text>();
        titlePanel = GameObject.Find("TitlePanel");
        GameOpening();
    }

    void Update()
    {
        //制限時間の更新
        scoreText.text = score.ToString();
        // ゲーム中ではなく、Spaceキーが押されたらtrueを返す。
        if (currentState == GameState.Opening && Input.GetKeyDown(KeyCode.Space))
        {
            dispatch(GameState.Playing);
        }

        if (currentState == GameState.Playing && 0 < limitTime)
        {
            limitTime -= Time.deltaTime;
            timeText.text = limitTime.ToString("F0");
        }
        //ゲームクリアの判定
        if(limitTime <= 0)
        {
            dispatch(GameState.Clear);
        }
        
    }

    //スコアの加算
    public void AddPoint()
    {
        score += addPoint;
    }

    //ゲームの進行状態による振り分け処理
    public void dispatch(GameState state)
    {
        GameState oldState = currentState;
        currentState = state;

        switch (state)
        {
            case GameState.Opening:
                GameOpening();
                break;
            case GameState.Playing:
                GameStart();
                break;
            case GameState.Clear:
                GameClear();
                break;
        }
    }

    //オープニング処理
    void GameOpening()
    {
        currentState = GameState.Opening;
        //動作の停止
        Time.timeScale = 0;
        // タイトル名のセット
        SetTitle("Game Start", Color.green);
    }

    //ゲームスタート処理
    void GameStart()
    {
        Time.timeScale = 1.0f;
        titlePanel.SetActive(false);
    }

    //ゲームクリア処理
    void GameClear()
    {
        SetTitle("Game Clear", Color.yellow);
        // 3秒後にオープニング処理を呼び出す
        Invoke("GameOpening", 3f);
    }

    //タイトル名のセットをする処理
    void SetTitle(string message, Color color)
    {
        titleText.text = message;
        titleText.color = color;
        titlePanel.SetActive(true);
    }
}
