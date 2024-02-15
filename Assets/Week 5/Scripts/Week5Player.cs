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

    void OnMouseDown(){
        SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
    }

    void Update(){
        //check mouse click
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)){
            //get mouse position in world space
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            //on right click set the attack flag
            if(Input.GetMouseButtonDown(1)){
                attack = true;
            }
        }
    }

    void FixedUpdate()
    {
        //ignore player input if dead
        if(hp <= 0){
            return;
        }

        //calculate the difference between where the knight is and where it should be
        difference = target - transform.position;
        //if the distance is large enough, move towards the target
        if(difference.magnitude > 0.5f){
            //move
            difference.Normalize();
            transform.Translate(difference * speed * Time.deltaTime);
            //start walk animation
            animator.SetFloat("Speed", speed);
        }
        //if the distance is close, stop walking animation, if attack flag is active then play attack animation
        else {
            animator.SetFloat("Speed", 0);
            if(attack){
                animator.SetTrigger("Attack");
            }
            //reset attack flag
            attack = false;
        }
    }

    void TakeDamage(int amount){
        //if dead ignore
        if(hp <= 0){
            return;
        }
        //if damage isn't healing, play hit animation
        if(amount > 0){
            animator.SetTrigger("Hit");
        }
        //reduce hp and healthbar
        hp -= amount;
        hpbar.value = hp;
        //don't heal past maxHp
        if(hp > maxHp) 
            hp = maxHp;

        if(hp <= 0){
            SendMessage("Death", SendMessageOptions.DontRequireReceiver);
        }
    }

    //play death animation
    void Death(){
        animator.SetTrigger("Dead");
    }

    //sword hit
    void OnTriggerEnter2D(){
        SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
    }
}
