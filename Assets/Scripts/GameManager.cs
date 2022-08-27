using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�Q�[���̐i�s�Ǘ���S�̓I�ȃp�����[�^�[��ێ�����
public class GameManager : MonoBehaviour
{
    //�v���C���[�̃X�R�A
    private int score;
    private Text scoreText;
    //���Z����|�C���g
    private int addPoint = 1;

    //��������
    private float limitTime = 10;
    private Text timeText;

    //�^�C�g���p�e�L�X�g�E�p�l��
    private Text titleText;
    private GameObject titlePanel;
    
    //�Q�[���̐i�s���
    public enum GameState
    {
        Opening,
        Playing,
        Clear
    }

    //���݂̃Q�[���i�s���
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
        //�������Ԃ̍X�V
        scoreText.text = score.ToString();
        // �Q�[�����ł͂Ȃ��ASpace�L�[�������ꂽ��true��Ԃ��B
        if (currentState == GameState.Opening && Input.GetKeyDown(KeyCode.Space))
        {
            dispatch(GameState.Playing);
        }

        if (currentState == GameState.Playing && 0 < limitTime)
        {
            limitTime -= Time.deltaTime;
            timeText.text = limitTime.ToString("F0");
        }
        //�Q�[���N���A�̔���
        if(limitTime <= 0)
        {
            dispatch(GameState.Clear);
        }
        
    }

    //�X�R�A�̉��Z
    public void AddPoint()
    {
        score += addPoint;
    }

    //�Q�[���̐i�s��Ԃɂ��U�蕪������
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

    //�I�[�v�j���O����
    void GameOpening()
    {
        currentState = GameState.Opening;
        //����̒�~
        Time.timeScale = 0;
        // �^�C�g�����̃Z�b�g
        SetTitle("Game Start", Color.green);
    }

    //�Q�[���X�^�[�g����
    void GameStart()
    {
        Time.timeScale = 1.0f;
        titlePanel.SetActive(false);
    }

    //�Q�[���N���A����
    void GameClear()
    {
        SetTitle("Game Clear", Color.yellow);
        // 3�b��ɃI�[�v�j���O�������Ăяo��
        Invoke("GameOpening", 3f);
    }

    //�^�C�g�����̃Z�b�g�����鏈��
    void SetTitle(string message, Color color)
    {
        titleText.text = message;
        titleText.color = color;
        titlePanel.SetActive(true);
    }
}
