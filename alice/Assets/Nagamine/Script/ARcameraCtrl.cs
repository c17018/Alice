using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARcameraCtrl : MonoBehaviour
{
    public GameObject backButton;
    AudioSource SE;

    void Start ()
    {
        if (!GameMainCtrl.f_gamestart)
            backButton.SetActive(false);
        SE = GetComponent<AudioSource>();
    }  	
	
	void Update ()
    {
		
	}

    public void GameMainBackButton()
    {
        SE.PlayOneShot(SE.clip);
        Invoke("MainSceneLoad", 0.5f);          
    }

    void MainSceneLoad()
    {
        SceneManager.LoadScene("GameMain");
    }
}
