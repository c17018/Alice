using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveTitle : MonoBehaviour {
    void Start(){
        Invoke("GOtitle", 60f);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            GOtitle();
        }
    }

    void GOtitle() {
        SceneManager.LoadScene(0);
    }
}
