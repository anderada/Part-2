using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week5Player : MonoBehaviour
{

    public float speed = 5f;
    Vector3 target;
    Vector3 difference;
    public Animator animator;
    public int hp = 10;
    int hitResetTimer = 5;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    void FixedUpdate()
    {
        if(hp <= 0){
            return;
        }

        hitResetTimer--;
        if(hitResetTimer <= 0){
            animator.SetBool("Hit", false);
        }

        if(Input.GetMouseButtonDown(0)){
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            target.y -= 0.5f;
            difference = target - transform.position;
            if(difference.magnitude < 1f){
                target = transform.position;
                animator.SetBool("Hit", true);
                hitResetTimer = 5;
                hp--;
                if(hp <= 0){
                    animator.SetBool("Dead", true);
                }
            }
            else{
                target.y += 0.5f;
            }
        }

        difference = target - transform.position;
        if(difference.magnitude > 0.5f){
            difference.Normalize();
            transform.Translate(difference * speed * Time.deltaTime);
            animator.SetFloat("Speed", speed);
        }
        else {
            animator.SetFloat("Speed", 0);
        }
    }
}
