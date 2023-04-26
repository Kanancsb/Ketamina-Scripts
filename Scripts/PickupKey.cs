using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{

    public GameObject FakeK;
    public GameObject RealK;
    public GameObject Hand;

    public AudioSource PickupK;

    public Transform Player;

    // Update is called once per frame

    void OnMouseOver(){

        if(Player){
            float dist = Vector3.Distance(Player.position, transform.position);
            Hand.SetActive(true);
            if (dist < 3){
        }

        if (Input.GetButtonDown("Action")){
            if (dist < 3){
                this.GetComponent<BoxCollider>().enabled = false;
                PickupK.Play();
                FakeK.SetActive(false);
                RealK.SetActive(true);
                Hand.SetActive(false);

            }
        } 
        }
    }

    void OnMouseExit(){
        Hand.SetActive(false);        
    }


}
