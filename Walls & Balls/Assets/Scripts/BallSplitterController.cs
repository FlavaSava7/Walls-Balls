using UnityEngine;
using System.Collections;

public class BallSplitterController : MonoBehaviour {

    public GameObject defaultBall;

    void OnDestroy() {
        Instantiate(defaultBall, transform.position, Quaternion.Euler(0f, 45f, 0f));
        Instantiate(defaultBall, transform.position, Quaternion.Euler(0f, 135f, 0f));
        GameController.self.ballSpawned(2);
    }
}
