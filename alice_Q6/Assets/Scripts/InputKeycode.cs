using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; //Enumを使用するために必要

public class InputKeycode : MonoBehaviour {
    public GameObject text;

    void Start() {
        text.GetComponent<Text>().text = "(none)".ToString();
    }

    void Update () {
        if (Input.GetMouseButton(0) || 
            Input.GetMouseButton(1) || 
            Input.GetMouseButton(2) || 
            Input.GetMouseButton(3) || 
            Input.GetMouseButton(4)) {
            return;
        }

        if (Input.anyKeyDown) {                 
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode))) {
                if (Input.GetKeyDown(code)) {
                    text.GetComponent<Text>().text = code.ToString();
                    break;
                }
            }
        }
    }

    public void Reset() {
        text.GetComponent<Text>().text = "(none)".ToString();
    }
}
