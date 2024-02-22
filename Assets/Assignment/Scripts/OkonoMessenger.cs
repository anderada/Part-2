using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkonoMessenger : MonoBehaviour
{
    List<GameObject> foods;
    public Okonomichi player;
    public List<GameObject> bars;
    float rest;
    float hunger;

    void Start(){
        foods = new List<GameObject>();
    }

    public void AddFood(GameObject toAdd){
        foods.Add(toAdd);
    }

    public Vector3 GetFoodPos(){
        if(foods.Count > 0)
            return foods[0].transform.position;
        else
            return Vector3.zero;
    }

    void EatFood(){
        if(foods.Count > 0){
            GameObject toDestroy = foods[0];
            foods.Remove(toDestroy);
            Destroy(toDestroy);
        }
        foreach(GameObject bar in bars){
            bar.SendMessage("Eat", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void SetNight(){
        player.SendMessage("Sleep", SendMessageOptions.DontRequireReceiver);
        foreach(GameObject food in foods){
            food.SendMessage("Sleep", SendMessageOptions.DontRequireReceiver);
        }
        foreach(GameObject bar in bars){
            bar.SendMessage("Sleep", SendMessageOptions.DontRequireReceiver);
            bar.SendMessage("SetRest", rest, SendMessageOptions.DontRequireReceiver);
            bar.SendMessage("SetHunger", hunger, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void SetDay(){
        player.SendMessage("Wake", SendMessageOptions.DontRequireReceiver);
        foreach(GameObject food in foods){
            food.SendMessage("Wake", SendMessageOptions.DontRequireReceiver);
        }
        foreach(GameObject bar in bars){
            bar.SendMessage("Sleep", SendMessageOptions.DontRequireReceiver);
            bar.SendMessage("SetRest", rest, SendMessageOptions.DontRequireReceiver);
            bar.SendMessage("SetHunger", hunger, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void SetRest(float newRest){
        rest = newRest;
    }

    public void SetHunger(float newHunger){
        hunger = newHunger;
    }
}
