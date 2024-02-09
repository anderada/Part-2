using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform targetTransform;
    Vector3 target;
    public float speed = 10f;
    Vector3 difference;

    void Start(){
        target = targetTransform.position;
        target.y += 0.5f;
        difference = target - transform.position;
        //rotate towards target
        float rotationTarget = Mathf.Rad2Deg * Mathf.Atan2(difference.y, difference.x) - 90;
        transform.Rotate(0, 0, (rotationTarget - transform.eulerAngles.z));
    }

    void FixedUpdate(){
        //move towards target
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(){
        Destroy(gameObject);
    }
}
