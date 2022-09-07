using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Hammer : MonoBehaviour
{
    private RectTransform canvasRect;
    private Animator hammerAnimator;
    private Vector3 mousePos, target;
    private float magnification;

    private ParticleSystem starPs;
    [SerializeField] GameObject starParticle;

    void Start()
    {
        canvasRect = GameObject.Find("HammerGUI").GetComponent<RectTransform>();
        hammerAnimator = GetComponent<Animator>();

        starPs = starParticle.GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        //スクリーン座標
        mousePos = Input.mousePosition;
        //倍率の計算
        //magnification = canvasRect.sizeDelta.x / Screen.width;
        //倍率をかけキャンバス座標にしてInput.mousePositionの起点を揃える
        //mousePos.x = mousePos.x * magnification - canvasRect.sizeDelta.x / 2;
        //mousePos.y = mousePos.y * magnification - canvasRect.sizeDelta.y / 2;
        //Canvas上なのでz座標は固定
        //mousePos.z = transform.localPosition.z;
        //ハンマーの画像をカーソルに追従
        //transform.localPosition = mousePos;
        mousePos.z = 10.0f;
        //ハンマーの画像をカーソルに追従
        target = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mousePos.z));       
        this.transform.position = target;

        if (Input.GetMouseButtonDown(0))
        {
            //SetTriggerでアニメーションMoveを発動させる
            hammerAnimator.SetTrigger("Move");
            //星のパーティクルをだす
            Instantiate(starPs, target, Quaternion.identity);
            starPs.Play();
        }
    }
}
