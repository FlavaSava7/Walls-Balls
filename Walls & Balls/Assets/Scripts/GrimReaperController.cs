using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimReaperController : MonoBehaviour {

    void OnTriggerExit(Collider other) {
        if (other.CompareTag(Tags.BALL)) {
            GameController.self.ballDestroyed(other.gameObject);
        }
        Destroy(other.gameObject);
    }

}
