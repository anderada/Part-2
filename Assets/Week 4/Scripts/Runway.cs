using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runway : MonoBehaviour
{
    public int score = 0;

    void OnTriggerStay2D(Collider2D plane){
        if(Vector3.Distance(transform.position, plane.transform.position) < 0.5f){
            Destroy(plane.gameObject);
            score++;
            Debug.Log("Score: " + score);
        }
    }
}
