using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodButton : MonoBehaviour
{
    public GameObject foodfab;
    public OkonoMessenger mes;

    public void newFood(){
        GameObject newFood = Instantiate(foodfab, new Vector3(Random.Range(-3,3), Random.Range(-2,2), 0), Quaternion.identity);
        mes.AddFood(newFood);
    }
}
