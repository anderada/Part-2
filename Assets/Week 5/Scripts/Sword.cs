using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform targetTransform;
    Vector3 target;
    public float speed = 100f;
    Vector3 difference;
    public Rigidbody2D rigidbody;


    void FixedUpdate(){
        target = targetTransform.position;
        target.y += 0.5f;
        difference = target - transform.position;
        difference = Vector3.Normalize(difference);
        //rotate towards target
        float rotationTarget = Mathf.Rad2Deg * Mathf.Atan2(difference.y, difference.x) - 90;
        transform.Rotate(0, 0, (rotationTarget - transform.eulerAngles.z));
        //move towards target
        rigidbody.AddForce(difference * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(){
        Destroy(gameObject);
    }
}
