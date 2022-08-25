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
