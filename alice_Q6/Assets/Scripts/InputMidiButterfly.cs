using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiJack;
using UnityEngine.SceneManagement;

public class InputMidiButterfly:MonoBehaviour {
        /*
           ド:0,12,24,36,48,60,72,84,96,108,120
           レ:2,14,26,38,50,62,74,86,98,110,122
           ミ:4,16,28,40,52,64,76,88,100,112,124
           ファ:5,17,29,41,53,65,77,89,101,113,125
           ソ:7,19,31,43,55,67,79,91,103,115,127
           ラ:9,21,33,45,57,69,81,93,105,117
           シ:11,23,35,47,59,71,83,95,107,119
        */
    int[,] scale = {
        {  0, 12, 24, 36, 48, 60, 72, 84, 96, 108, 120 },
        {  2, 14, 26, 38, 50, 62, 74, 86, 98, 110, 122 },
        {  4, 16, 28, 40, 52, 64, 76, 88, 100, 112, 124 },
        {  5, 17, 29, 41, 53, 65, 77, 89, 101, 113, 125 },
        {  7, 19, 31, 43, 55, 67, 79, 91, 103, 115, 127 },
        {  9, 21, 33, 45, 57, 69, 81, 93, 105, 117, 117 },
        { 11, 23, 35, 47, 59, 71, 83, 95, 107, 119, 119 }
    };

    int[] ButterflySongNum = 
        { 7, 4, 4, 5, 2, 2, 0, 2, 4, 5, 7, 7, 7, /*7, 4, 4, 4, 5, 2, 2, 2, 0, 4, 7, 7, 4, 4, 4 */};

    [SerializeField]
    GameObject[] Butterfly;

    [SerializeField]
    GameObject Text;
    [SerializeField]
    AudioClip[] ac;

    int songNum = 0;

    void Start() {
        songNum = 0;
    }

    void Update() {
        if (songNum == ButterflySongNum.Length) {
            Invoke("moveResult", 1);
        }

        for (int i = 0; i < scale.GetLength(0); i++) {
            for (int j = 0; j < scale.GetLength(1); j++) {
                if (MidiMaster.GetKeyDown(scale[i, j])) {
                    Butterflysong(scale[i, j]);
                }
            }
        }

        if (songNum < 3) {
            for (int i = 1; i < Butterfly.Length; i++) {
                Butterfly[i].SetActive(false);
            }
            Butterfly[0].SetActive(true);
        } else if (songNum < 6) {
            Butterfly[0].SetActive(false);
            Butterfly[1].SetActive(true);
        } else if (songNum < 10) {
            Butterfly[1].SetActive(false);
            Butterfly[2].SetActive(true);
        } else if (songNum < 13) {
            Butterfly[2].SetActive(false);
            Butterfly[3].SetActive(true);
        } else {
            Butterfly[3].SetActive(false);
            Butterfly[4].SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("Q6_title");
        }
    }

    void Butterflysong(int getScale) {
        Text text = Text.GetComponent<Text>();
        AudioSource audioSource = GetComponent<AudioSource>();
        getScale += 12;
        int remainder;
        remainder = getScale % 12;

        switch (remainder) {
            case 0:
                text.text = "ド";
                audioSource.PlayOneShot(ac[0]);
                break;
            case 2:
                text.text = "レ";
                audioSource.PlayOneShot(ac[1]);
                break;
            case 4:
                text.text = "ミ".ToString();
                audioSource.PlayOneShot(ac[2]);
                break;
            case 5:
                text.text = "ファ";
                audioSource.PlayOneShot(ac[3]);
                break;
            case 7:
                text.text = "ソ";
                audioSource.PlayOneShot(ac[4]);
                break;
            case 9:
                text.text = "ラ";
                audioSource.PlayOneShot(ac[5]);
                break;
            case 11:
                text.text = "シ";
                audioSource.PlayOneShot(ac[6]);
                break;
            default:
                text.text = "";
                break;
        }

        if (getScale % 12 == ButterflySongNum[songNum]) {
            songNum++;
        } else {
            songNum = 0;
        }
    }

    void moveResult() {
        SceneManager.LoadScene("Q6_result");
        Destroy(gameObject);
    }
}