using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System;
public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public GameObject settings;
    public GameObject minigames;
    public Button[] gamesButtons;
    public bool OpenAllButtons = false;
    void Awake()
    {
        
        for (int i = 0; i < 15; i++)
        {
            gamesButtons[i].onClick.AddListener(delegate { LevelManager.LoadMinigame(i); });
        }
    }
    void Start()
    {
        CheckButtons();
        Back();
    }
    public void NewGame()
    {
        SceneManager.LoadScene("StandartGame");
    }
    public void OpenSettings()
    {
        //menu.SetActive(false);
        //settings.SetActive(true);
    }
    public void OpenMiniGames()
    {
        menu.SetActive(false);
        minigames.SetActive(true);
    }
    public void Back()
    {
        menu.SetActive(true);
        //settings.SetActive(false);
        minigames.SetActive(false);
    }
    void CheckButtons()
    {
        if (OpenAllButtons)
        {
            for (int i = 0; i < 15; i++)
            {
                gamesButtons[i].interactable = true;
            }
        }
        else
        {
            //check levels
        }
    }
}
