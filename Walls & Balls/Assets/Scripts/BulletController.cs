using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public Bullet bullet;

    float speed;
    int damage;
    Rigidbody rb;

    void Start() {
        transform.gameObject.name = bullet.name;
        speed = bullet.speed;
        damage = bullet.damage;

        rb = transform.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);

        GameObject.Destroy(gameObject, 5f);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == Tags.BALL) {
            BallController ballController = other.gameObject.GetComponent<BallController>();
            ballController.getHit(damage);
            Destroy(gameObject);
        } else if (other.gameObject.tag == Tags.ITEM) {
            Destroy(gameObject);
        }

    }


}
