using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mole : MonoBehaviour,IPointerClickHandler
{
    //���b�����ɏグ���������邩�̒l
    private float perSeconds;
    //�グ�������Ă��邩�ۂ�
    private bool isUp;
    private GameManager GameManager;
   

    private void Start()
    {
        isUp = false;
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
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

    //�n���}�[�����O�����N���b�N�����Ƃ��X�R�A�����Z����
    public void OnPointerClick(PointerEventData pointerData)
    {
        Debug.Log(gameObject.name + " ���N���b�N���ꂽ!");
        GameManager.AddPoint();
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