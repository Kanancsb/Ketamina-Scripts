using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupNote : MonoBehaviour
{
    public GameObject Text;
    public GameObject NoteOB;
    public GameObject NoteTrigger;

    public AudioSource pSound;

    public Transform Player;


    void OnMouseOver(){

        if(Player){
            float dist = Vector3.Distance(Player.position, transform.position);
            if (dist < 3){
            Text.SetActive(true);
            if (Input.GetButtonDown("Action")){
                Text.SetActive(false);
                NoteOB.SetActive(true);
                NoteTrigger.SetActive(true);
            } 
            }
        }
    }

    void OnMouseExit(){
        Text.SetActive(false);        
    }

    void Update(){
        if(NoteOB.activeInHierarchy){
            Text.SetActive(false);
        }
        if(Input.GetButtonDown("Drop")){
                NoteOB.SetActive(false);
            } 
    }

}
