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
        //ignore player input if dead
        if(hp <= 0){
            return;
        }

        //check mouse click
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)){
            //get mouse position in world space
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            //ignore mouse clicks in UI area
            if(target.y < 4){
                //adjust target to center of knight
                target.y -= 0.5f;
                //find distance between click and knight
                difference = target - transform.position;
                //if click is close enough to knight, deal damage
                if(difference.magnitude < 1f){
                    target = transform.position;
                    SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
                }
                //if click is away from knight, undo adjustment to centre of knight
                else{
                    target.y += 0.5f;
                }
            }
            //if click is in the UI area, set target back to where the knight is now
            else{
                target = transform.position;
            }
            //on right click set the attack flag
            if(Input.GetMouseButtonDown(1)){
                attack = true;
            }
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
        animator.SetBool("Dead", true);
    }

    //sword hit
    void OnTriggerEnter2D(){
        SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
    }
}
