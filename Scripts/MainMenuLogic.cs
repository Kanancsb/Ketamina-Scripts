using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject optionsMenu;
    private GameObject loading;
    private GameObject buttonsMenu;

    public GameObject Continue;

    public AudioSource buttonSound;
    public AudioSource MenuMusic;

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    //public SaveLoadManager saveLoad;

    private SaveGameManager saveGameManager;

    Resolution[] resolutions;

    void Start(){

        //saveLoad = FindObjectOfType<SaveLoadManager>();

        saveGameManager = FindObjectOfType<SaveGameManager>();

        if (saveGameManager != null && saveGameManager.IsSave){
            Continue.SetActive(true);
        }

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

        resolutions = Screen.resolutions;
        
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i=0; i < resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void StartButton(){
        loading.GetComponent<Canvas>().enabled = true;
        mainMenu.GetComponent<Canvas>().enabled = false;
        buttonSound.Play();
        SceneManager.LoadScene("EN-US");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (saveGameManager != null){
            saveGameManager.IsSave = false;
        }
    }

    public void ContinueButton(){
        loading.GetComponent<Canvas>().enabled = true;
        mainMenu.GetComponent<Canvas>().enabled = false;
        buttonSound.Play();
        SceneManager.LoadScene("EN-US");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    public void StartButtonPTBR(){
        loading.GetComponent<Canvas>().enabled = true;
        mainMenu.GetComponent<Canvas>().enabled = false;
        buttonSound.Play();
        SceneManager.LoadScene("PT-BR");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (saveGameManager != null){
            saveGameManager.IsSave = false;
        }
    }

    public void ContinueButtonPTBR(){
        loading.GetComponent<Canvas>().enabled = true;
        mainMenu.GetComponent<Canvas>().enabled = false;
        buttonSound.Play();
        SceneManager.LoadScene("PT-BR");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
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

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;

    }

    public void MuteMusic(){
        if(!MenuMusic.mute){
            MenuMusic.mute = true;
        }else{
            MenuMusic.mute = !MenuMusic.mute;
        }
    }

    public void SetVolume (float volume){
        audioMixer.SetFloat("volume", volume);
    }

    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}