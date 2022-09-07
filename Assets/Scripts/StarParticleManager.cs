using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarParticleManager : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyStarParticle", 1.0f);
    }

    void DestroyStarParticle()
    {
        Destroy(gameObject);
    }
}
