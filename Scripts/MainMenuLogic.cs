using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject optionsMenu;
    private GameObject loading;
    private GameObject buttonsMenu;

    public AudioSource buttonSound;

    void Start(){
        mainMenu = GameObject.Find("MainMenuCanvas");
        optionsMenu = GameObject.Find("OptionsCanvas");
        loading = GameObject.Find("LoadingCanvas");
        buttonsMenu = GameObject.Find("ButtonsCanvas");

        mainMenu.GetComponent<Canvas>().enabled = true;
        optionsMenu.GetComponent<Canvas>().enabled = false;
        loading.GetComponent<Canvas>().enabled = false;
        optionsMenu.GetComponent<Canvas>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void StartButton(){
        loading.GetComponent<Canvas>().enabled = true;
        mainMenu.GetComponent<Canvas>().enabled = false;
        buttonSound.Play();
        SceneManager.LoadScene("SampleScene");

    }

    public void OptionsButton(){
        buttonSound.Play();
        mainMenu.GetComponent<Canvas>().enabled = false;
        optionsMenu.GetComponent<Canvas>().enabled = true;

    }

    public void ButtonsButton(){
        buttonSound.Play();
        mainMenu.GetComponent<Canvas>().enabled = false;
        optionsMenu.GetComponent<Canvas>().enabled = false;
        buttonsMenu.GetComponent<Canvas>().enabled = true;

    }

    public void ExitGameButton(){
        buttonSound.Play();
        Application.Quit();

    }

    public void ReturnToMainMenuButton(){
        buttonSound.Play();
        mainMenu.GetComponent<Canvas>().enabled = true;
        optionsMenu.GetComponent<Canvas>().enabled = false;

    }


}