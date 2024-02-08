using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Heal(){
        SendMessage("TakeDamage", -1, SendMessageOptions.DontRequireReceiver);       
    }
}
