using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevelName;
    public GameObject mainMenu;
    public GameObject settings;

    private void Start()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void openMainMenu()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void openSettings()
    {
        settings.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevelName);
    }

    public void EndGame()
    {
        Application.Quit();

    }




}
