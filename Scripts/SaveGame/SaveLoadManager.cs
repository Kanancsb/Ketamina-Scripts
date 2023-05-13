using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject[] activeObjects;

    void Start()
    {
        LoadData();
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            SaveData();
        }

        if (Input.GetButtonDown("Drop"))
        {
            LoadData();
        }
    }

    void SaveData()
    {
        // Salva a posição do jogador
        PlayerPrefs.SetFloat("PlayerPosX", playerTransform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerTransform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", playerTransform.position.z);

        // Salva quais objetos estão ativos no jogador
        for (int i = 0; i < activeObjects.Length; i++)
        {
            PlayerPrefs.SetInt("Object" + i, activeObjects[i].activeSelf ? 1 : 0);
        }

        PlayerPrefs.Save();
    }

    void LoadData()
    {
        // Carrega a posição do jogador
        Vector3 playerPos = new Vector3(
            PlayerPrefs.GetFloat("PlayerPosX", 0),
            PlayerPrefs.GetFloat("PlayerPosY", 0),
            PlayerPrefs.GetFloat("PlayerPosZ", 0)
        );

        playerTransform.position = playerPos;

        // Carrega quais objetos estão ativos no jogador
        for (int i = 0; i < activeObjects.Length; i++)
        {
            activeObjects[i].SetActive(PlayerPrefs.GetInt("Object" + i, 0) == 1);
        }
    }
}
