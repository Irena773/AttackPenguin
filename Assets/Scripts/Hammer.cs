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
        //�X�N���[�����W
        mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        //�n���}�[�̉摜���J�[�\���ɒǏ]
        target = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x+10, mousePos.y-5, mousePos.z));       
        this.transform.position = target;

        if (Input.GetMouseButtonDown(0))
        {
            //SetTrigger�ŃA�j���[�V����Move�𔭓�������
            hammerAnimator.SetTrigger("Move");
        }
    }
}
