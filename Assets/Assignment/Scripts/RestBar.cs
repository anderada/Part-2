using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestBar : MonoBehaviour
{
    float rest = 1;
    public float decrementRate = 0.01f;
    public Slider bar;
    public OkonoMessenger mes;

    void FixedUpdate(){
        rest -= decrementRate * Time.deltaTime;
        if(rest < 0) rest = 0;
        if(rest > 1) rest = 1;
        mes.SetRest(rest);
        bar.value = rest;
    }

    public void SetRest(float newRest){
        rest = newRest;
    }
}
