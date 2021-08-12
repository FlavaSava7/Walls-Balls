using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallBooster : MonoBehaviour {

    public float amount;

    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == Tags.BALL) {
            BallController bc = other.gameObject.GetComponent<BallController>();
            bc.move(transform.forward * amount);
        }
    }

}
