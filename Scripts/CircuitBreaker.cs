using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBreaker : MonoBehaviour
{

    public GameObject[] lights;

    public GameObject flashlight;

    public GameObject hand;

    public Transform Player;

    public AudioSource switchClick;

    public bool powerIsOn;

    void Start(){
        foreach (GameObject ob in lights){
            ob.SetActive(false);
        }
    }

    void OnMouseOver(){
        if(Player){
            float dist = Vector3.Distance(Player.position, transform.position);
            if(dist < 3 && !powerIsOn){
                hand.SetActive(true);
                if(!powerIsOn && Input.GetButtonDown("Action")){
                    switchClick.Play();
                    powerIsOn = true;
                    foreach(GameObject ob in lights){
                        ob.SetActive(true);
                    }
                }
            }
        }
    }

    void OnMouseExit(){
        hand.SetActive(false);
    }

}
