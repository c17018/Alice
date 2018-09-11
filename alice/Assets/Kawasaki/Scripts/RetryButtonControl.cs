using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButtonControl : MonoBehaviour {


    public void RetryButton() {
        SceneManager.LoadScene("Q4");
    }
}
