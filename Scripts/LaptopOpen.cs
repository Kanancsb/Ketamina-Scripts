using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopOpen : MonoBehaviour
{
    public Transform Player;

    public GameObject hand;
    public GameObject laptop;

    void OnMouseOver(){
        if(Player){
            float dist = Vector3.Distance(Player.position, transform.position);
            hand.SetActive(true);
            if(dist < 3){
                if(Input.GetButtonDown("Action")){
                    laptop.SetActive(true);
                }
            }
        }
    }

    void OnMouseExit(){
        hand.SetActive(false);
    }
}
