using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject hpBar;
    public Text ballAmountTxt;
    public Text scoreTxt;

    Slider hpSlider;
    Text hpTxt;
    int ballAmount;
    int score;

    void Start() {
        int hp = PlayerController.self.hp;
        int maxHP = PlayerController.self.maxHP;

        hpSlider = hpBar.GetComponent<Slider>();
        hpSlider.value = hp;
        hpSlider.maxValue = maxHP;

        hpTxt = hpBar.transform.Find("Text").GetComponent<Text>();
        hpTxt.text = hp.ToString();

        ballAmount = 0;
        ballAmountTxt.text = "X" + ballAmount;

        score = 0;
        scoreTxt.text = score.ToString();


        PlayerController.eventPlayerHP += handleHPBar;
        GameController.eventBallSpawn += handleBallSpawn;
        GameController.eventBallDestroyed += handleBallDestroyed;
    }


    public void handleHPBar(int amount) {
        hpSlider.value += amount;
        hpTxt.text = hpSlider.value.ToString();
    }

    public void handleBallSpawn(int amount) {
        ballAmount += amount;
        ballAmountTxt.text = "X" + ballAmount;
    }

    public void handleBallDestroyed(Ball ball) {
        score += ball.points;
        scoreTxt.text = score.ToString();
    }

}
