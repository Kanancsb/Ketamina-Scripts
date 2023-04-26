using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{

    public GameObject onOB;
    public GameObject offOB;

    public GameObject iText;

    public GameObject lightOB;

    public AudioSource switchClick;

    public Transform Player;

    public bool lightsAreOn;
    public bool lightsAreOff;
    
    void Start(){

        lightsAreOn = false;
        lightsAreOff = true;
        onOB.SetActive(false);
        offOB.SetActive(true);
        lightOB.SetActive(false);

    }

    void OnMouseOver(){
        if(Player){
            float dist = Vector3.Distance(Player.position, transform.position);
            if(dist < 3){
                iText.SetActive(true);
                if(lightsAreOn && Input.GetButtonDown("Action")){
                    switchClick.Play();
                    lightOB.SetActive(false);
                    onOB.SetActive(false);
                    offOB.SetActive(true);
                    lightsAreOff = true;
                    lightsAreOn = false;                           
                }else if(lightsAreOff && Input.GetButtonDown("Action")){
                    switchClick.Play();
                    lightOB.SetActive(true);
                    onOB.SetActive(true);
                    offOB.SetActive(false);
                    lightsAreOff = false;
                    lightsAreOn = true;                     
                }
            }
        }

    }

    void OnMouseExit(){
        iText.SetActive(false);
    }

}
