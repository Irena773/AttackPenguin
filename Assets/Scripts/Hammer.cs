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

    void Start()
    {
        canvasRect = GameObject.Find("HammerGUI").GetComponent<RectTransform>();
        hammerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        //�X�N���[�����W
        mousePos = Input.mousePosition;
        //�{���̌v�Z
        //magnification = canvasRect.sizeDelta.x / Screen.width;
        //�{���������L�����o�X���W�ɂ���Input.mousePosition�̋N�_�𑵂���
        //mousePos.x = mousePos.x * magnification - canvasRect.sizeDelta.x / 2;
        //mousePos.y = mousePos.y * magnification - canvasRect.sizeDelta.y / 2;
        //Canvas��Ȃ̂�z���W�͌Œ�
        //mousePos.z = transform.localPosition.z;
        //�n���}�[�̉摜���J�[�\���ɒǏ]
        //transform.localPosition = mousePos;

        //�n���}�[�̉摜���J�[�\���ɒǏ]
        target = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 100));       
        this.transform.position = target;

        if (Input.GetMouseButtonDown(0))
        {
            //SetTrigger�ŃA�j���[�V����Move�𔭓�������
            hammerAnimator.SetTrigger("Move");
        }
    }
}
