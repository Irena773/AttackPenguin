using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mole : MonoBehaviour,IPointerClickHandler
{
   
    //何秒おきに上げ下げをするかの値
    public float perSeconds;
    //何秒おきに上げ下げをするかの値を保存しておく
    private float savePerSeconds;
    //上げ下げしているか否か
    private bool isUp;
    private GameManager GameManager;
    //叩かれたかどうか(一回だけしかクリックを受け付けない)
    private bool isPushed;
   
    private ParticleSystem heartPs;
    [SerializeField] GameObject heartParticle;


    //モグラを叩く音
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
        //n秒おきに上げ下げを行う
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

    //ハンマーがモグラをクリックしたときスコアを加算する
    public void OnPointerClick(PointerEventData pointerData)
    {
        if (isUp == true && isPushed == false)
        {
            //叩いた音をだす
            audioSource.PlayOneShot(punchClip);
            //ハートのパーティクルをだす
            Instantiate(heartPs, this.transform.position, Quaternion.identity);
            heartPs.Play();
            //スコアの加算
            GameManager.AddPoint();
            isPushed = true;
           
        }
    }

    IEnumerator MoleUpDown()
    {
        isUp = true;
        for (int i = 0; i < 16; i++)
        {
            //現在のモグラの位置を基準にして上に移動
            transform.Translate(0, 0.1f, 0);
            //0.02秒停止
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 16; i++)
        {
            //現在のモグラの位置を基準にして下に移動
            transform.Translate(0, -0.1f, 0);
            yield return new WaitForSeconds(0.02f);
        }
        isUp = false;
        isPushed=false;
    }

}