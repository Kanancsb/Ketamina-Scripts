using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{

    public GameObject menu;
    public GameObject resume;
    public GameObject mainMenu;
    public GameObject notesMenu;
    public GameObject buttonsMenu;
    public GameObject mentalnotesMenu;
    public GameObject optionsMenu;

    public GameObject note01;
    public GameObject note02;
    public GameObject note03;
    public GameObject note04;
    public GameObject note05;

    public GameObject[] NoteTrigger;

    Resolution[] resolutions;
    
    public AudioSource buttonSound;

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    private bool on;
    private bool off;

    void Start(){
        foreach(GameObject trigger in NoteTrigger){
            trigger.SetActive(false);
        }
        menu.SetActive(false);
        notesMenu.SetActive(false);
        buttonsMenu.SetActive(false);
        mentalnotesMenu.SetActive(false);
        optionsMenu.SetActive(false);
        off = true;
        on = false;

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

    void Update(){

        if(off && Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 0;
            menu.SetActive(true);
            off = false;
            on = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            note01.SetActive(false);
            note02.SetActive(false);
            note03.SetActive(false);
            note04.SetActive(false);
            note05.SetActive(false);
        }else if(on && Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 1;
            menu.SetActive(false);
            off = true;
            on = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            note01.SetActive(false);
            note02.SetActive(false);
            note03.SetActive(false);
            note04.SetActive(false);
            note05.SetActive(false);
        }
    }

    public void Resume(){
        buttonSound.Play();
        Time.timeScale = 1;
        menu.SetActive(false);
        notesMenu.SetActive(false);
        buttonsMenu.SetActive(false);
        mentalnotesMenu.SetActive(false);
        off = true;
        on = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        note01.SetActive(false);
        note02.SetActive(false);
        note03.SetActive(false);
        note04.SetActive(false);
        note05.SetActive(false);
    }

    public void MainMenu(){
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");

    }

    public void Exit(){
        buttonSound.Play();
        Application.Quit();
    }

    public void NotesM(){
        buttonSound.Play();
        menu.SetActive(false);
        notesMenu.SetActive(true);
    }

    public void Menu(){
        buttonSound.Play();
        if(note01.activeInHierarchy || note02.activeInHierarchy || note03.activeInHierarchy || note04.activeInHierarchy || note05.activeInHierarchy){
            note01.SetActive(false);
            note02.SetActive(false);
            note03.SetActive(false);
            note04.SetActive(false);
            note05.SetActive(false);
        }else{
            menu.SetActive(true);
            notesMenu.SetActive(false);
            buttonsMenu.SetActive(false);
            mentalnotesMenu.SetActive(false);
            optionsMenu.SetActive(false);
        }
    }

    public void Buttons(){
        buttonSound.Play();
        menu.SetActive(false);
        buttonsMenu.SetActive(true);
    }

    public void MentalNotes(){
        buttonSound.Play();
        menu.SetActive(false);
        mentalnotesMenu.SetActive(true);
    }

    public void OptionsMenu(){
        menu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    
    public void OpenNote01(){
        for(int i=0; i < NoteTrigger.Length; i++){
            if(NoteTrigger[0].activeInHierarchy){
                note01.SetActive(true);
            }
        }
        note02.SetActive(false);
        note03.SetActive(false);
        note04.SetActive(false);
        note05.SetActive(false);
    }

    public void OpenNote02(){
        for(int i=0; i < NoteTrigger.Length; i++){
            if(NoteTrigger[1].activeInHierarchy){
                note02.SetActive(true);
            }
        }
        note01.SetActive(false);
        note03.SetActive(false);
        note04.SetActive(false);
        note05.SetActive(false);
    }

    public void OpenNote03(){
        for(int i=0; i < NoteTrigger.Length; i++){
            if(NoteTrigger[2].activeInHierarchy){
                note03.SetActive(true);
            }
        }
        note01.SetActive(false);
        note02.SetActive(false);
        note04.SetActive(false);
        note05.SetActive(false);
    }

    public void OpenNote04(){
        for(int i=0; i < NoteTrigger.Length; i++){
            if(NoteTrigger[3].activeInHierarchy){
                note04.SetActive(true);
            }
        }
        note01.SetActive(false);
        note02.SetActive(false);
        note03.SetActive(false);
        note05.SetActive(false);
    }

    public void OpenNote05(){
        for(int i=0; i < NoteTrigger.Length; i++){
            if(NoteTrigger[4].activeInHierarchy){
                note05.SetActive(true);
            }
        }
        note01.SetActive(false);
        note02.SetActive(false);
        note03.SetActive(false);
        note04.SetActive(false);
    }

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;

    }

    public void SetVolume (float volume){
        audioMixer.SetFloat("volume", volume);
    }

    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
