using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mole : MonoBehaviour,IPointerClickHandler
{
   
    //���b�����ɏグ���������邩�̒l
    public float perSeconds;
    //���b�����ɏグ���������邩�̒l��ۑ����Ă���
    private float savePerSeconds;
    //�グ�������Ă��邩�ۂ�
    private bool isUp;
    private GameManager GameManager;
    //�@���ꂽ���ǂ���(��񂾂������N���b�N���󂯕t���Ȃ�)
    private bool isPushed;
   
    private ParticleSystem heartPs;
    [SerializeField] GameObject heartParticle;


    //���O����@����
    public AudioClip punchClip;
    private AudioSource audioSource;

    private void Start()
    {
        savePerSeconds = perSeconds;
        isUp = false;
        isPushed = false;
 
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        heartPs = heartParticle.GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //n�b�����ɏグ�������s��
        perSeconds -= Time.deltaTime;
        if (perSeconds <= 0)
        {
            if (!isUp)
            {    
                StartCoroutine("MoleUpDown");
            }
            perSeconds = savePerSeconds;        
        }   
    }

    //�n���}�[�����O�����N���b�N�����Ƃ��X�R�A�����Z����
    public void OnPointerClick(PointerEventData pointerData)
    {
        if (isUp == true && isPushed == false)
        {
            //�@������������
            audioSource.PlayOneShot(punchClip);
            //�n�[�g�̃p�[�e�B�N��������
            Instantiate(heartPs, this.transform.position, Quaternion.identity);
            heartPs.Play();
            //�X�R�A�̉��Z
            GameManager.AddPoint();
            isPushed = true;
           
        }
    }

    IEnumerator MoleUpDown()
    {
        isUp = true;
        for (int i = 0; i < 16; i++)
        {
            //���݂̃��O���̈ʒu����ɂ��ď�Ɉړ�
            transform.Translate(0, 0.1f, 0);
            //0.02�b��~
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(0.5f);
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