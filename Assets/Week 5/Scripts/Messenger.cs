using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messenger : MonoBehaviour
{
    public GameObject knight;
    public GameObject hpBar;

    void Start(){
        SetDamage(PlayerPrefs.GetInt("hp", 10));
    }

    public void Heal(){
        knight.SendMessage("TakeDamage", -1, SendMessageOptions.DontRequireReceiver);
        hpBar.SendMessage("TakeDamage", -1, SendMessageOptions.DontRequireReceiver);
    }

    void TakeDamage(int amount){
        knight.SendMessage("TakeDamage", amount, SendMessageOptions.DontRequireReceiver);
        hpBar.SendMessage("TakeDamage", amount, SendMessageOptions.DontRequireReceiver);
    }

    void SetDamage(int amount){
        knight.SendMessage("SetDamage", amount, SendMessageOptions.DontRequireReceiver);
        hpBar.SendMessage("SetDamage", amount, SendMessageOptions.DontRequireReceiver);
    }
}
