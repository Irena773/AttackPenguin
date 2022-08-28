using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private string mainSceneName = "Main";

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene(mainSceneName);
    }

    public void OnClickResultButton()
    {
    }
}
