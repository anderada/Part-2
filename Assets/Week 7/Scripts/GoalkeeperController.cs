using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D goalkeeper;
    float lineDistance = 2f;

    void FixedUpdate(){
        if(Controller.SelectedPlayer != null){
            Vector3 direction = Controller.SelectedPlayer.transform.position - transform.position;
            if(direction.magnitude < lineDistance * 2){
                direction /= 2;
                goalkeeper.transform.position = transform.position + direction;
            }
            else{
                direction.Normalize();
                direction *= lineDistance;
                goalkeeper.transform.position = transform.position + direction;
            }
        }
        else{
            goalkeeper.transform.position = transform.position;
        }
    }
}
