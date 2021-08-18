using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public static UIController self;
    public GameObject hpBar;
    public Text ballAmountTxt;
    public Text scoreTxt;

    Slider hpSlider;
    Text hpTxt;
    int ballAmount;
    int score;

    void Awake() {
        self = this;
    }

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
    }


    public void handleHPBar(int amount) {
        hpSlider.value += amount;
        if (hpSlider.value < 0) {
            hpSlider.value = 0;
        }
        hpTxt.text = hpSlider.value.ToString();
    }

    public void handleBallSpawn(int amount) {
        ballAmount += amount;
        if (ballAmount < 0) {
            ballAmount = 0;
        }
        ballAmountTxt.text = "X" + ballAmount;
    }

    public void handleScore(int amount) {
        score += amount;
        if (score < 0) {
            score = 0;
        }
        scoreTxt.text = score.ToString();
    }

}
