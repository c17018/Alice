using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    float speed = 10.0f;
    GameController GC;
    Rigidbody rb;


    void Start() {
        GC = GameObject.Find("GameController").GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();


    }

    void FixedUpdate() {
        if (!GC.movestart) { return; }
        if (GC.clear || GC.gameover) {
            rb.velocity = Vector3.zero;
            return;
        }

        Move();

    }

    void Update() {


    }

    void Move() {

        Vector3 dir = Vector3.zero;

        dir.x = Input.acceleration.x;
        dir.z = Input.acceleration.y;

        // Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(dir * speed);

    }


    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "D_card1" && GC.flag1) {
            GC.CurrectSE();
            GC.Currectimage_h1.SetActive(true);
            GC.flag1 = false;
            GC.flag4 = true;
        } else if (other.gameObject.tag == "D_card4" && GC.flag4) {
            GC.CurrectSE();
            GC.Currectimage_d4.SetActive(true);
            GC.flag4 = false;
            GC.flag5 = true;
        } else if (other.gameObject.tag == "D_card5" && GC.flag5) {
            GC.CurrectSE();
            GC.Currectimage_c5.SetActive(true);
            GC.flag5 = false;
            GC.flag10 = true;
        } else if (other.gameObject.tag == "D_card10" && GC.flag10) {
            GC.CurrectSE();
            GC.Currectimage_s10.SetActive(true);
            GC.flag10 = false;
            GC.Clear();
        } else {
            GC.inCurrectSE();
            GC.Reset(this.gameObject);

        }

    }
}
