using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpBar : MonoBehaviour
{
    Slider hpslider;

    void Start(){
        hpslider = GetComponent<Slider>();
    }

    void TakeDamage(int amount){
        hpslider.value -= amount;
    }

    void SetDamage(int amount){
        hpslider.value = amount;
    }
}
