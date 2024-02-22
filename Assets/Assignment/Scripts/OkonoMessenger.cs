using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkonoMessenger : MonoBehaviour
{
    List<GameObject> foods;
    public Okonomichi player;

    // Start is called before the first frame update
    void Start()
    {
        foods = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void SetNight(){
        player.SendMessage("Sleep", SendMessageOptions.DontRequireReceiver);
        foreach(GameObject food in foods){
            food.SendMessage("Sleep", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void SetDay(){
        player.SendMessage("Wake", SendMessageOptions.DontRequireReceiver);
        foreach(GameObject food in foods){
            food.SendMessage("Wake", SendMessageOptions.DontRequireReceiver);
        }
    }
}
