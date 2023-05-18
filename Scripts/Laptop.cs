using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laptop : MonoBehaviour
{
    public GameObject laptopOB;

    public GameObject animateOB;

    public Animator OpenCloset;

    public InputField inputField;
    public string answer = "12345";

    public AudioSource correct;
    public AudioSource wrong;

    public bool open;

    public GameObject SaveOB;

    void Start(){
        open = false;
        laptopOB.SetActive(false);
    }

    public void Update(){
        if(laptopOB.activeInHierarchy){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (inputField.isFocused){
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void Execute(){
        if(inputField.text == answer){
            correct.Play();
            StartCoroutine(Opening());
            Debug.Log("Código correto!");
            SaveOB.SetActive(true);
            
        }else{
            inputField.text = "";
            wrong.Play();
        }
    }

    public void Exit(){
        laptopOB.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    IEnumerator Opening(){
        OpenCloset.Play("ClosetOpening");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

}
