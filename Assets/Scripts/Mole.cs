using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    //���b�����ɏグ���������邩�̒l
    private float perSeconds;
    //�グ�������Ă��邩�ۂ�
    private bool isUp;

    private void Start()
    {
        isUp = false;
    }

    void Update()
    {
        //2�b�����ɏグ�������s��
        perSeconds -= Time.deltaTime;
        if (perSeconds <= 0)
        {
            if (!isUp)
            {
                isUp = true;
                StartCoroutine("MoleUpDown");
            }
            perSeconds = 2.0f;
        }       
    }

    public void OnClickMole()
    {
        Debug.Log("hoge");
    }

    IEnumerator MoleUpDown()
    {
        for (int i = 0; i < 16; i++)
        {
            //���݂̃��O���̈ʒu����ɂ��ď�Ɉړ�
            transform.Translate(0, 5f, 0);
            //0.02�b��~
            yield return new WaitForSeconds(0.02f);
        }

        for (int i = 0; i < 16; i++)
        {
            //���݂̃��O���̈ʒu����ɂ��ĉ��Ɉړ�
            transform.Translate(0, -5f, 0);
            yield return new WaitForSeconds(0.02f);
        }
        isUp = false;
    }

    


}