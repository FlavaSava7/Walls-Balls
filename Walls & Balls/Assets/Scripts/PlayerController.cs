using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public GameObject bullet;
    public GameObject bulletPool;
    public int hp;
    public int maxHP;

    Vector3 mousePos;

    public static PlayerController self;
    public static event Action<int> eventPlayerHP;

    void Awake() {
        self = this;
    }

    void Start() {

    }

    void Update() {
        rotate();
        shoot();
    }


    public void rotate() {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit)) {
            mousePos = hit.point;
            //used transform y so we lock rotation on a single axis
            Vector3 lookAtPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(lookAtPos);
        }
    }

    public void shoot() {
        //TODO: Pooling
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            GameObject bulletGO = Instantiate(bullet, transform.position, transform.rotation);
            bulletGO.transform.SetParent(bulletPool.transform);
        }
    }

    public void getHit(int amount) {
        hp -= amount;
        if (hp <= 0) {
            hp = 0;
        }
        eventPlayerHP.Invoke(-amount);
    }

    public void addHp(int amount) {
        hp += amount;
        if (hp > maxHP) {
            amount = Mathf.Abs(hp - maxHP - amount);
            hp = maxHP;
        }
        eventPlayerHP.Invoke(amount);
    }


}
