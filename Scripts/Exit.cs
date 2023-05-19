using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Transform Player;

    public GameObject siren;
    public GameObject Open;
    public GameObject Close;
    
    public GameObject hand;

    private SaveLoadManager saveLoadManager;


    void Start(){

        saveLoadManager = FindObjectOfType<SaveLoadManager>();

        siren.SetActive(false);
        hand.SetActive(false);
        Close.SetActive(true);
    }

    void Update(){
        if(siren.activeInHierarchy){
            Open.SetActive(true);
            Close.SetActive(false);
        }
    }

    void OnMouseOver(){
        if(Player){
            float dist = Vector3.Distance(Player.position, transform.position);
            if(dist < 3){
                hand.SetActive(true);
                if(siren.activeInHierarchy && Input.GetButtonDown("Action")){
                    saveLoadManager.DeleteSave();
                    if (SceneManager.GetActiveScene().name == "PT-BR"){
                        SceneManager.LoadScene("MainMenuPT-BR");
                    }else{
                        SceneManager.LoadScene("MainMenu");
                    }
                }
            }
        }
    }

    void OnMouseExit(){
        hand.SetActive(false);
    }

}
