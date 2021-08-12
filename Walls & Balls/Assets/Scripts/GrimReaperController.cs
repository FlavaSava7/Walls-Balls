using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimReaperController : MonoBehaviour {

    void OnTriggerExit(Collider other) {
        GameObject.Destroy(other.gameObject);
    }

}
