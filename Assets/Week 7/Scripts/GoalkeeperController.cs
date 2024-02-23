using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D goalkeeper;
    float lineDistance = 2f;
    Vector3 target;
    public float speed = 10f;

    void FixedUpdate(){
        if(Controller.SelectedPlayer != null){
            Vector3 direction = Controller.SelectedPlayer.transform.position - transform.position;
            if(direction.magnitude < lineDistance * 2){
                direction /= 2;
                target = transform.position + direction;
            }
            else{
                direction.Normalize();
                direction *= lineDistance;
                target = transform.position + direction;
            }
        }
        else{
            target = transform.position;
        }

        float step = speed * Time.deltaTime;
        goalkeeper.transform.position = Vector3.MoveTowards(goalkeeper.transform.position, target, step);
    }
}
