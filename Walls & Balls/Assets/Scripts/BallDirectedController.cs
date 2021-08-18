using UnityEngine;
using System.Collections;

public class BallDirectedController : MonoBehaviour {

    public Ball ball;
    public int intiateTime;

    SphereCollider sphereCollider;
    BallController ballController;

    void Start() {
        sphereCollider = GetComponent<SphereCollider>();
        ballController = GetComponent<BallController>();
        StartCoroutine(timer());
    }


    IEnumerator timer() {
        while (true) {
            --intiateTime;
            if (intiateTime <= 0) {
                targetPlayer();
                yield break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    void targetPlayer() {
        sphereCollider.isTrigger = true;
        Vector3 direction = PlayerController.self.gameObject.transform.position - gameObject.transform.position;
        ballController.move(direction.normalized);
    }



    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag(Tags.PLAYER)) {
            PlayerController.self.getHit(ball.damage);
            ballController.destroyBall();
        }
    }

}
