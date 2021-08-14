using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour {

    [Header("Balls Config")]
    public GameObject[] balls;
    public GameObject ballsSpawnPlacesParent;
    public GameObject ballsPool;
    public int ballsMaxAmount;
    public float ballsSpawningTime;
    GameObject[] ballsSpawnPlaces;

    [Header("Items Config")]
    public GameObject[] items;
    public GameObject itemsSpawnPlacesParent;
    public GameObject itemsPool;
    public int itemsMaxAmount;
    public float itemsSpawningTime;
    GameObject[] itemsSpawnPlaces;

    public static event Action<int> eventBallSpawn;
    public static event Action<Ball> eventBallDestroyed;

    public static GameController self;

    void Awake() {
        self = this;
    }

    void Start() {
        setSpawnPlaces(ballsSpawnPlacesParent, ref ballsSpawnPlaces);
        setSpawnPlaces(itemsSpawnPlacesParent, ref itemsSpawnPlaces);

        StartCoroutine(spawner(ballsSpawnPlaces, ballsPool, balls, ballsMaxAmount, ballsSpawningTime, Tags.BALL));
        StartCoroutine(spawner(itemsSpawnPlaces, itemsPool, items, itemsMaxAmount, itemsSpawningTime, Tags.HEART));
    }


    void Update() {

    }

    private void setSpawnPlaces(GameObject placesParent, ref GameObject[] places) {
        places = new GameObject[placesParent.transform.childCount];
        for (int i = 0; i < places.Length; i++) {
            places[i] = placesParent.transform.GetChild(i).gameObject;
        }
    }

    IEnumerator spawner(GameObject[] spawnPlaces, GameObject pool, GameObject[] prefabs, int poolMaxAmount, float time, string tag) {
        yield return new WaitForSeconds(time);
        while (true) {
            if (pool.transform.childCount >= poolMaxAmount) {
                yield return new WaitForSeconds(time);
                continue;
            }
            int spawnIdx = Random.Range(0, spawnPlaces.Length);
            int pfIdx = Random.Range(0, prefabs.Length);
            GameObject go = Instantiate(prefabs[pfIdx], spawnPlaces[spawnIdx].transform.position, getSpawnerRotation(tag), pool.transform);
            if (tag == Tags.BALL) {
                eventBallSpawn.Invoke(1);
            }

            yield return new WaitForSeconds(time);
        }
    }


    private Quaternion getSpawnerRotation(string tag) {
        switch (tag) {
            case Tags.BALL:
                return Quaternion.Euler(0f, Random.Range(0, 360f), 0f);
            case Tags.HEART:
            default:
                return Quaternion.identity;
        }
    }

    public void ballDestroyed(GameObject go) {
        eventBallSpawn.Invoke(-1);
        Ball ball = go.GetComponent<BallController>().ball;
        eventBallDestroyed(ball);
    }
}
