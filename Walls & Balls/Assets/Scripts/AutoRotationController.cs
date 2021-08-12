using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotationController : MonoBehaviour {

    public float speed;
    public bool xAxis;
    public bool yAxis;
    public bool zAxis;

    Vector3 rotation;
    void Start() {
        if (xAxis) {
            rotation = new Vector3(10f, 0f, 0f);
        } else if (yAxis) {
            rotation = new Vector3(0f, 10f, 0f);
        } else if (zAxis) {
            rotation = new Vector3(0f, 0f, 10f);
        } else {
            rotation = Vector3.zero;
        }

    }

    void Update() {
        transform.Rotate(rotation * Time.deltaTime * speed);
    }

}
