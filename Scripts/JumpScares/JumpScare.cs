using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public GameObject triggerOB;

    public AudioSource soundtrigger;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            Destroy(triggerOB);
            soundtrigger.Play();
        }
    }

}
