using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    Vector3 Camerapos;
    GameObject Playerobj;

    [SerializeField]
    float Minx = -3;

    [SerializeField]
    float Maxx = 3;

    [SerializeField]
    float Minz = -0.5f;

    [SerializeField]
    float Maxz = 0.5f;

    [SerializeField]
    float y = 10;

    void Start() {
        //Playerobj = GameObject.FindWithTag("Player");

    }

    
    void FixedUpdate() {
        if (Playerobj == null) {
            Playerobj = GameObject.FindWithTag("Player");
            }
        //Playerpos = Playerobj.transform.position;
        Camerapos = Playerobj.transform.position;

        this.gameObject.transform.position = new Vector3(Mathf.Clamp(Camerapos.x, Minx, Maxx),
                                                         y, Mathf.Clamp(Camerapos.z, Minz, Maxz));

    }
}
