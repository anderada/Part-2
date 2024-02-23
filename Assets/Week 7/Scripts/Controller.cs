using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public static Player SelectedPlayer {get; private set;}
    bool spaceHeld = false;
    bool fire = false;
    float flickPower = 0;
    public Slider flickSlider;
    public static int score = 0;
    public TextMeshProUGUI scoreText;

    public static void setSelectedPlayer(Player toSet){
        if(SelectedPlayer != null){
            SelectedPlayer.Selected(false);
        }
        SelectedPlayer = toSet;
        SelectedPlayer.Selected(true);
    }

    void Update(){
        if(Input.GetKey("space")){
            spaceHeld = true;
        }
        if(Input.GetKeyUp("space")){
            fire = true;
            spaceHeld = false;
        }
    }

    void FixedUpdate(){
        if(spaceHeld){
            flickPower += 1f * Time.deltaTime;
        }
        if(fire){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePos - SelectedPlayer.transform.position;
            direction.Normalize();
            direction *= flickPower;
            SelectedPlayer.Flick(direction);
            flickPower = 0;
            fire = false;
        }
        flickSlider.value = flickPower;
        scoreText.text = "Score: " + score;
    }
}
