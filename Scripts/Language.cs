using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    
    public AudioSource buttonSound;

    public void EnUs(){
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
    }
    
    public void PtBR(){
        buttonSound.Play();
        SceneManager.LoadScene("MainMenuPT-BR");
    }
}
