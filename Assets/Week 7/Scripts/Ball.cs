using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform kickoff;
    public Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("wat");
        Controller.score++;
        transform.position = kickoff.position;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        Debug.Log(Controller.score);
    }
}
