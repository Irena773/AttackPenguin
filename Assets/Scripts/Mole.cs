using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    //何秒おきに上げ下げをするかの値
    private float perSeconds;
    //上げ下げしているか否か
    private bool isUp;

    private void Start()
    {
        isUp = false;
    }

    void Update()
    {
        //2秒おきに上げ下げを行う
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
            //現在のモグラの位置を基準にして上に移動
            transform.Translate(0, 5f, 0);
            //0.02秒停止
            yield return new WaitForSeconds(0.02f);
        }

        for (int i = 0; i < 16; i++)
        {
            //現在のモグラの位置を基準にして下に移動
            transform.Translate(0, -5f, 0);
            yield return new WaitForSeconds(0.02f);
        }
        isUp = false;
    }

    


}