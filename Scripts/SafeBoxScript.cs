using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeBoxScript : MonoBehaviour
{
    public GameObject safeboxUI;
    public GameObject SafeBox;

    public GameObject animateOB;

    public Text textOB;
    public string answer = "1234";

    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;

    public Animator open;
    public bool animate;

    public Behaviour Movement;
    public GameObject control;

    public GameObject SaveOB;

    public void Start(){
        safeboxUI.SetActive(false);
    }

    public void Number(int number){
        textOB.text += number.ToString();
        button.Play();
    }

    public void Execute(){
        if(textOB.text == answer){
            correct.Play();
            StartCoroutine(opening());
            safeboxUI.SetActive(false);
            SafeBox.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            SaveOB.SetActive(true);
            Movement.enabled = true;
            control.SetActive(true);
            
        }else{
            wrong.Play();
            textOB.text = "";
        }
    }

    public void Clear(){
        textOB.text = "";
        button.Play();
    }

    public void Exit(){
        safeboxUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Movement.enabled = true;
        control.SetActive(true);
    }

    public void Update(){
        if(safeboxUI.activeInHierarchy){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Movement.enabled = false;
            control.SetActive(false);
        }
    }

    IEnumerator opening(){
        open.Play("Opening");
        animate = true;
        yield return new WaitForSeconds(.5f);
    }
}
