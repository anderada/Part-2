using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Okonomichi : MonoBehaviour
{
    public Animator animator;
    Vector3 target;
    public OkonoMessenger mes;
    public float speed = 5f;
    public AnimationCurve walkCurve;
    float initialDistance;

    // Start is called before the first frame update
    void Start()
    {
        target = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Eat") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Pet"))
            target = mes.GetFoodPos();
        else
            target = Vector3.zero;
        if(target.x != 0 && target.y != 0)
            initialDistance = (transform.position - target).magnitude;
    }

    void FixedUpdate(){
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Eat") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Pet")){
            if(target.x != 0 && target.y != 0){
                animator.SetBool("Walking", true);
                Vector3 difference = transform.position - target;
                float walkSpeed = Time.deltaTime * speed * walkCurve.Evaluate(difference.magnitude / initialDistance);
                transform.position = Vector3.Lerp(transform.position, target, walkSpeed);

                if(difference.magnitude < 0.5f){
                    mes.SendMessage("EatFood", SendMessageOptions.DontRequireReceiver);
                    animator.SetBool("Walking", false);
                    animator.SetTrigger("Eat");
                    target = Vector3.zero;
                }
            }
        }
    }

    void OnMouseDown(){
        animator.SetBool("Pet", true);
        target = Vector3.zero;
    }

    void OnMouseUp(){
        animator.SetBool("Pet", false);
    }
}
