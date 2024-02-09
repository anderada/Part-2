using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Week5Player : MonoBehaviour
{

    public float speed = 5f;
    Vector3 target;
    Vector3 difference;
    public Animator animator;
    public int hp = 10;
    public int maxHp = 10;
    public Slider hpbar;
    bool attack = false;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    void FixedUpdate()
    {
        Debug.Log(hp);

        if(hp <= 0){
            return;
        }

        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)){
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            if(target.y < 4){
                target.y -= 0.5f;
                difference = target - transform.position;
                if(difference.magnitude < 1f){
                    target = transform.position;
                    SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
                    if(hp <= 0){
                        SendMessage("Death", SendMessageOptions.DontRequireReceiver);
                    }
                }
                else{
                    target.y += 0.5f;
                }
            }
            else{
                target = transform.position;
            }

            if(Input.GetMouseButtonDown(1)){
                attack = true;
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
            if(attack){
                animator.SetTrigger("Attack");
            }
            attack = false;
        }
    }

    void TakeDamage(int amount){
        if(hp <= 0){
            return;
        }
        if(amount > 0){
            animator.SetTrigger("Hit");
        }
        hp -= amount;
        hpbar.value = hp;
        if(hp > maxHp) 
            hp = maxHp;
    }

    void Death(){
        animator.SetBool("Dead", true);
    }
}
