using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    public Ball ball;
    public GameObject hpBar;

    HPBarController hpBarController;
    Rigidbody rb;
    int hp;
    int speed;
    int damage;
    int points;
    BallType type;


    void Start() {
        rb = GetComponent<Rigidbody>();

        transform.gameObject.name = ball.name;
        hp = ball.hp;
        speed = ball.speed;
        damage = ball.damage;
        points = ball.points;
        type = ball.type;

        hpBarController = hpBar.GetComponent<HPBarController>();
        hpBarController.initHPBar(hp);

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
            destroyBall();
            return;
        }
        hpBarController.setHPBar(hp);
    }

    public void destroyBall() {
        Destroy(gameObject);
        GameController.self.ballDestroyed(gameObject);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag(Tags.PLAYER)) {
            PlayerController.self.getHit(damage);
        } else if (collision.gameObject.CompareTag(Tags.FLOOR) && rb.constraints.Equals(RigidbodyConstraints.None)) {
            //prevent balls from flying around when hitting each other
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }


}
