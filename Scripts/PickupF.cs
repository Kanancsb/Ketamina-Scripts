using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupF : MonoBehaviour
{

    public GameObject ActionDisplay;
    public GameObject FakeF;
    public GameObject RealF;

    public Transform Player;

    // Update is called once per frame

    void OnMouseOver(){

        if(Player){
            float dist = Vector3.Distance(Player.position, transform.position);
            if (dist < 3){
            ActionDisplay.SetActive(true);
        }

        if (Input.GetButtonDown("Action")){
            if (dist < 3){
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                FakeF.SetActive(false);
                RealF.SetActive(true);

            }
        } 
        }
    }

    void OnMouseExit(){
        ActionDisplay.SetActive(false);
        
    }


}
