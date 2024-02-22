using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerBar : MonoBehaviour
{
    float hunger = 1;
    public float decrementRate = 0.01f;
    public Slider bar;
    public OkonoMessenger mes;

    void FixedUpdate(){
        hunger -= decrementRate * Time.deltaTime;
        if(hunger > 1) hunger = 1;
        if(hunger < 0) hunger = 0;
        mes.SetHunger(hunger);
        bar.value = hunger;
    }

    void Eat(){
        hunger += 0.5f;
        if(hunger > 1) hunger = 1;
    }

    public void SetHunger(float newHunger){
        hunger = newHunger;
    }
}
