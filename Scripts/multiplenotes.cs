using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplenotes : MonoBehaviour
{
    public GameObject hand;
    public GameObject [] NoteOB;
    public GameObject [] NoteTrigger;

    public GameObject nextbutton;
    public GameObject backbutton;

    private int i = 0;

    public AudioSource TurnPage;

    public Transform Player;

    public Behaviour Movement;
    public GameObject control;

    void Start(){
        foreach(GameObject noteOB in NoteOB){
            noteOB.SetActive(false);
        }
        nextbutton.SetActive(false);
        backbutton.SetActive(false);
    }

    void OnMouseOver(){
        if(Player){
            float dist = Vector3.Distance(Player.position, transform.position);
            if(dist < 3){
                hand.SetActive(true);
                if(Input.GetButtonDown("Action")){
                    nextbutton.SetActive(true);
                    backbutton.SetActive(true);
                    NoteOB[i].SetActive(true);
                    foreach(GameObject noteTrigger in NoteTrigger){
                        noteTrigger.SetActive(true);
                    }
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Movement.enabled = false;
                    control.SetActive(false);
                }
            }
        }
    }

    void OnMouseExit(){
        hand.SetActive(false);
    }

    void Update(){
        if(Input.GetButtonDown("Drop")){
            foreach(GameObject noteOB in NoteOB){
                noteOB.SetActive(false);
            }
            nextbutton.SetActive(false);
            backbutton.SetActive(false);
            i=0;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Movement.enabled = true;
            control.SetActive(true);
        }
    }

    public void Next(){
        if(i < NoteOB.Length - 1){
            i++;
            NoteOB[i].SetActive(true);
        }
    }

    public void Back(){
        if(i > 0){
            NoteOB[i].SetActive(false);
            i--;
        }
    }
}
