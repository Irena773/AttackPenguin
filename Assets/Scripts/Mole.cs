using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class Mole : MonoBehaviour,IPointerClickHandler
{
    //���b�����ɏグ���������邩�̒l
    private float perSeconds;
    //�グ�������Ă��邩�ۂ�
    private bool isUp;
    private GameManager GameManager;
    //�@���ꂽ���ǂ���(��񂾂������N���b�N���󂯕t���Ȃ�)
    private bool isPushed;
   
    private ParticleSystem heartPs;
    [SerializeField] GameObject heartParticle;
    
    private void Start()
    {
        isUp = false;
        isPushed = false;
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        heartPs = heartParticle.GetComponentInChildren<ParticleSystem>();
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
        if (isUp == true && isPushed == false)
        {
            //���̃p�[�e�B�N��������
            Instantiate(heartPs, this.transform.position, Quaternion.identity);
            heartPs.Play();
            Debug.Log(gameObject.name + " ���N���b�N���ꂽ!");
            GameManager.AddPoint();
            isPushed = true;
        }
    }

    IEnumerator MoleUpDown()
    {
        for (int i = 0; i < 16; i++)
        {
            //���݂̃��O���̈ʒu����ɂ��ď�Ɉړ�
            transform.Translate(0, 0.1f, 0);
            //0.02�b��~
            yield return new WaitForSeconds(0.02f);
        }

        for (int i = 0; i < 16; i++)
        {
            //���݂̃��O���̈ʒu����ɂ��ĉ��Ɉړ�
            transform.Translate(0, -0.1f, 0);
            yield return new WaitForSeconds(0.02f);
        }
        isUp = false;
        isPushed=false;
    }

    


}