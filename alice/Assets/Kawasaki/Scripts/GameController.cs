using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

    public bool clear = false;
    public bool gameover = false;
    public bool flag1 = true;
    public bool flag4 = false;
    public bool flag5 = false;
    public bool flag10 = false;

    public GameObject Playerobj;
    public GameObject Retrybutton;
    public GameObject Mainbackbutton;

    private int cutend = 3;

    [SerializeField]
    private GameObject startbutton;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Text countdownText;

    private bool startflag = false;

    float time = 60.0f;
    Text timeText;
    float countdowntime = 3.5f;

    public bool movestart = false;

    AudioSource audiosource;
    [SerializeField]
    AudioClip countSE;

    [SerializeField]
    AudioClip currectSE;

    [SerializeField]
    AudioClip incurrectSE;

    public GameObject Currectimage_h1;
    public GameObject Currectimage_d4;
    public GameObject Currectimage_c5;
    public GameObject Currectimage_s10;



    void Start() {
        timeText = GameObject.Find("timeText").GetComponent<Text>();
        Instantiate(Playerobj, Vector3.zero, Quaternion.identity);
        audiosource = GetComponent<AudioSource>();



    }

    void Update() {
        if (!startflag) { return; }

        if (countdowntime > 0) {
            countdowntime -= Time.deltaTime;
            countdownText.GetComponent<Text>().text = countdowntime.ToString("F0");
            if (countdowntime <= 0) {
                Destroy(countdownText);
                movestart = true;
            }
            return;

        } else {

            if (clear) { return; }

            if (time <= 0) {
                GameOver();
                return;
            }


            time -= Time.deltaTime;
            timeText.text = "残り" + time.ToString("F0") + "秒";


        }


    }

    public void Reset(GameObject destroy) {

        //GameObject Player = GameObject.FindWithTag("Player");
        Destroy(destroy);
        Instantiate(Playerobj, Vector3.zero, Quaternion.identity);

        Currectimage_h1.SetActive(false);
        Currectimage_d4.SetActive(false);
        Currectimage_c5.SetActive(false);
        Currectimage_s10.SetActive(false);

        flag1 = true;
        flag4 = false;
        flag5 = false;
        flag10 = false;
    }

    public void Clear() {
        //SceneManager.LoadScene("Clear");
        timeText.text = null;
        clear = true;
        GameMainCtrl.ceGet += cutend;
        GameMainCtrl.f_Q4 = true;
        //GameObject.Find("RetryButton").SetActive(true);
        Invoke("GoCutEnd", 1.0f);
        //SceneManager.LoadScene("CutEnd");


    }

    void GameOver() {
        //SceneManager.LoadScene("GameOver");
        timeText.text = null;
        gameover = true;
        Retrybutton.SetActive(true);
        Mainbackbutton.SetActive(true);

    }

    public void StartButton() {
        startbutton.SetActive(false);
        panel.SetActive(false);
        startflag = true;
        audiosource.PlayOneShot(countSE);
        
    }

    public void CurrectSE() {
        audiosource.PlayOneShot(currectSE);
    }

    public void inCurrectSE() {
        audiosource.PlayOneShot(incurrectSE);
    }
    void GoCutEnd() {
        SceneManager.LoadScene("CutEnd");
    }
}