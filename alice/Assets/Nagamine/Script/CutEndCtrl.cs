using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutEndCtrl : MonoBehaviour
{
    public Text cutend_num;
    AudioSource SE1;
    AudioSource SE2;

    void Start ()
    {
        AudioSource[] audiosources = GetComponents<AudioSource>();
        SE1 = audiosources[0];
        SE2 = audiosources[1];

        cutend_num.text = GameMainCtrl.ceGet.ToString();
        GameMainCtrl.ceNum += GameMainCtrl.ceGet;

        Invoke("SEplay", 0.5f);
    }  	

    void SEplay()
    {
        SE2.PlayOneShot(SE2.clip);
    }
	
	void Update ()
    {
		
	}

    public void GameMainBackButton()
    {
        // シーン遷移前に ceGet を初期化
        GameMainCtrl.ceGet = 0;
        SE1.PlayOneShot(SE1.clip);
        Invoke("MainSceneLoad", 0.5f);
    }

    void MainSceneLoad()
    {
        SceneManager.LoadScene("GameMain");
    }
}
