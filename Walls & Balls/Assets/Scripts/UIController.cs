using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject hpBar;
    public Text ballAmountTxt;

    Slider hpSlider;
    Text hpTxt;
    int ballAmount;

    void Start() {
        int hp = PlayerController.self.hp;
        int maxHP = PlayerController.self.maxHP;

        hpSlider = hpBar.GetComponent<Slider>();
        hpSlider.value = hp;
        hpSlider.maxValue = maxHP;

        hpTxt = hpBar.transform.Find("Text").GetComponent<Text>();
        hpTxt.text = hp.ToString();

        ballAmount = 0;
        handleBallSpawn(0);

        PlayerController.eventPlayerHP += handleHPBar;
        GameController.eventBallSpawn += handleBallSpawn;
    }


    public void handleHPBar(int amount) {
        hpSlider.value += amount;
        hpTxt.text = hpSlider.value.ToString();
    }

    public void handleBallSpawn(int amount) {
        ballAmount += amount;
        ballAmountTxt.text = "X" + ballAmount;
    }

}
