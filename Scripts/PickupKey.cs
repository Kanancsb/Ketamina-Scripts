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

    private SaveLoadManager saveLoad;

	public void Start(){
		saveLoad = FindObjectOfType<SaveLoadManager>();
	}


    void OnMouseOver(){

        if(Player){
            float dist = Vector3.Distance(Player.position, transform.position);
            if (dist < 3){
                Hand.SetActive(true);
                if (Input.GetButtonDown("Action")){
                this.GetComponent<BoxCollider>().enabled = false;
                PickupK.Play();
                FakeK.SetActive(false);
                RealK.SetActive(true);
                Hand.SetActive(false);
                saveLoad.SaveData();
                } 
            }
        }
    }

    void OnMouseExit(){
        Hand.SetActive(false);        
    }

    void Update(){
        if(RealK.activeInHierarchy){
            FakeK.SetActive(false);
        }
    }


}
