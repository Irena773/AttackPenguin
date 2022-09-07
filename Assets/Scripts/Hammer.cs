using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Hammer : MonoBehaviour
{
    private Animator hammerAnimator;
    private Vector3 mousePos, target;

    void Start()
    {
        hammerAnimator = GetComponent<Animator>();
        
    }

    void Update()
    {
        //スクリーン座標
        mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        //ハンマーの画像をカーソルに追従
        target = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mousePos.z));       
        this.transform.position = target;

        if (Input.GetMouseButtonDown(0))
        {
            //SetTriggerでアニメーションMoveを発動させる
            hammerAnimator.SetTrigger("Move");
            

        }
    }
}
