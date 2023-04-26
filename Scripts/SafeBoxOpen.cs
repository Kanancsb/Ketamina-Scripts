using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBoxOpen : MonoBehaviour
{
    public Transform Player;

    public GameObject hand;
    public GameObject SafeBoxUI;

    public void OnMouseOver(){
        if(Player){
            float distance = Vector3.Distance(Player.position, transform.position);
            if(distance < 4){
                hand.SetActive(true);
                if(Input.GetButtonDown("Action")){
                    SafeBoxUI.SetActive(true);
                }
            }
        }
    }

    public void OnMouseExit(){
        hand.SetActive(false);
    }
    
}
