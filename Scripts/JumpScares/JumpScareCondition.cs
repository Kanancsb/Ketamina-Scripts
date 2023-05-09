using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareCondition : MonoBehaviour
{
    public GameObject triggerCondition;
    public GameObject triggerOB;

    public GameObject fearOB;
    public GameObject flashlight;


    void Start(){
        fearOB.SetActive(false);
    }

    void Update(){
        if(triggerCondition.activeInHierarchy){
            fearOB.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other){
        if(fearOB.activeInHierarchy && other.gameObject.tag == "Player"){
            flashlight.SetActive(false);
            Destroy(fearOB);
            Destroy(triggerOB);
        }
    }

}
