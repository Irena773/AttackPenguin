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
