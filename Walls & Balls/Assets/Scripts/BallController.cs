using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public Ball ball;

    Rigidbody rb;
    int hp;
    int speed;
    int damage;
    int points;
    void Start() {
        rb = GetComponent<Rigidbody>();

        transform.gameObject.name = ball.name;
        hp = ball.hp;
        speed = ball.speed;
        damage = ball.damage;
        points = ball.points;

        move(transform.forward);
    }


    void Update() {
    }

    void FixedUpdate() {
    }

    public void move(Vector3 direction) {
        rb.velocity = Vector3.zero;//stop
        rb.AddForce(direction * speed, ForceMode.Impulse);
    }

    public void getHit(int amount) {
        hp -= amount;
        if (hp <= 0) {
            Destroy(gameObject);
            GameController.self.ballDestroyed(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag(Tags.PLAYER)) {
            PlayerController.self.getHit(damage);
        } else if (collision.gameObject.CompareTag(Tags.MAP) && rb.constraints.Equals(RigidbodyConstraints.None)) {
            //prevent balls from flying around when hitting each other
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

}
