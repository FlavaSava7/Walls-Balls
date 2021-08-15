using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour {

    public Slider hpSlider;

    Canvas canvas;
    void Start() {
        canvas = gameObject.GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void initHPBar(int amount) {
        hpSlider.maxValue = amount;
        hpSlider.value = amount;
    }


    public void setHPBar(int amount) {
        hpSlider.value = amount;
        if (!canvas.enabled) {
            canvas.enabled = true;
        }
    }


}
