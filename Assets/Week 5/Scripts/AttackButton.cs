using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public Transform spawn;
    public GameObject sword;
    public Transform target;

    public void SpawnSword(){
        GameObject newSword = Instantiate(sword, spawn);
        newSword.GetComponent<Sword>().targetTransform = target;
    }
}
