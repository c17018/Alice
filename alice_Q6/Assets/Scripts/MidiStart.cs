using System.Collections;
using System.Collections.Generic;
using MidiJack;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidiStart : MonoBehaviour {
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

    void Update() {
        for (int i = 0; i < scale.GetLength(0); i++) {
            for (int j = 0; j < scale.GetLength(1); j++) {
                if (MidiMaster.GetKeyDown(scale[i, j])) {
                    GameObject camera = GameObject.FindWithTag("MainCamera");
                    AudioSource AudioSource = camera.GetComponent<AudioSource>();
                    AudioSource.Play();
                    Invoke("gameStart", 0.3f);
                }
            }
        }
    }
    
    void gameStart() {
        SceneManager.LoadScene("Q6_main");
    }
}
