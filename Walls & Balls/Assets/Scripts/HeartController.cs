using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour {

    public Heart heart;

    int healAmount;

    void Start() {
        healAmount = heart.healAmount;
    }


    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == Tags.BULLET) {
            PlayerController.self.addHp(healAmount);
            GameObject.Destroy(gameObject);
        }
    }
}
