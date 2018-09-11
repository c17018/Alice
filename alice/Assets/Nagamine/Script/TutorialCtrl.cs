using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialCtrl : MonoBehaviour
{
    AudioSource SE;
                   
    void Start ()
    {
        SE = GetComponent<AudioSource>();
    } 	
	
	void Update ()
    {
		
	}

    public void ARcamera()
    {
        SE.PlayOneShot(SE.clip);
        Invoke("ARcameraSceneLoad", 0.5f);        
    }

    void ARcameraSceneLoad()
    {
        SceneManager.LoadScene("ARcamera");
    }
}
