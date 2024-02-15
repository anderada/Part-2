using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Week5Player : MonoBehaviour
{

    public float speed = 5f;
    Vector3 target;
    Vector3 difference;
    public Animator animator;
    public int hp = 10;
    public int maxHp = 10;
    bool attack = false;
    public GameObject messenger;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    void OnMouseDown(){
        messenger.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
    }

    void Update(){
        //ignore mouse clicks on UI
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
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

    public void TakeDamage(int amount){
        //if damage isn't healing, play hit animation
        if(amount > 0){
            animator.SetTrigger("Hit");
        }
        //reduce hp
        hp -= amount;

        //don't heal past maxHp
        if(hp > maxHp) 
            hp = maxHp;
        if(hp < 0)
            hp = 0;
            
        //update playerprefs
        PlayerPrefs.SetInt("hp", hp);

        if(hp <= 0){
            Death();
        }
    }

    void SetDamage(int amount){
        hp = amount;
        if(hp <= 0){
            Death();
        }
    }

    //play death animation
    void Death(){
        animator.SetTrigger("Dead");
    }

}
