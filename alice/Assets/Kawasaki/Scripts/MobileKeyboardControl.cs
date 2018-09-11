using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MobileKeyboardControl : MonoBehaviour {

    TouchScreenKeyboard keyboard;
    public Text test;
    int cutend = 4;

    AudioSource audio;
    public AudioClip currectSE;
    public AudioClip incurrectSE;

    bool is_keyboard;


    void Start() {
        //keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        audio = GetComponent<AudioSource>();
        

    }

    void Update() {
        if (!is_keyboard) { return; }

        if (!keyboard.active) {
            if (keyboard.text == "ウサギ" || keyboard.text == "うさぎ") {
                audio.PlayOneShot(currectSE);
                test.GetComponent<Text>().text = "正解";
                GameMainCtrl.ceGet += cutend;
                GameMainCtrl.f_Q5 = true;
                is_keyboard = false;
                Invoke("GoCutEnd",1);
               

            } else {
                audio.PlayOneShot(incurrectSE);
                test.GetComponent<Text>().text = "不正解";
                is_keyboard = false;

            }
            //keyboard.text = null;
        }
    }

    public void OpenKeyboard() {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        is_keyboard = true;

    }

    void GoCutEnd() {
        SceneManager.LoadScene("CutEnd");
    }
}
