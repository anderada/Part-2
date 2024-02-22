using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Color highlight;
    Color normal;
    SpriteRenderer playerbase;

    void Start(){
        highlight = new Color(0.3f, 0.5f, 1);
        normal = GetComponent<SpriteRenderer>().color;
        playerbase = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        Selected(true);
    }

    public void Selected(bool selected){
        if(selected){
            playerbase.color = highlight;
        }
        else{
            playerbase.color = normal;
        }
    }
}
