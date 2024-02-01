using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject plane;
    float timer = 0;
    float timerTarget = 0;

    void Update(){
        timer += Time.deltaTime;
        if(timer >= timerTarget){
            Instantiate(plane, new Vector3(Random.Range(0,4), Random.Range(0,4), 0), Quaternion.identity);
            timer = 0;
            timerTarget = Random.Range(5,15);
        }
    }
}
