using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

    public ItemType itemType;
    public int heartHeal;
    public int starPoints;

    void Start() {
    }


    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == Tags.BULLET) {
            applyItemBuff();
            Destroy(gameObject);
        }
    }

    void applyItemBuff() {
        switch (itemType) {
            case ItemType.HEART:
                PlayerController.self.addHp(heartHeal);
                break;
            case ItemType.STAR:
                GameController.self.scorePoints(starPoints);
                break;
            default:
                break;
        }

    }
}
