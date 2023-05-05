using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Transform Player;

    public GameObject siren;
    
    public GameObject hand;


    void Start(){
        siren.SetActive(false);
        hand.SetActive(false);
    }

    void OnMouseOver(){
        if(Player){
            float dist = Vector3.Distance(Player.position, transform.position);
            if(dist < 3){
                hand.SetActive(true);
                if(siren.activeInHierarchy && Input.GetButtonDown("Action")){
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }

    void OnMouseExit(){
        hand.SetActive(false);
    }

}
