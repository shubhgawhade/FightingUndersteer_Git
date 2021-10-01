using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] 
    private GameObject mainMenu;
    
    [SerializeField]
    private GameObject trackSelectMenu;
    
    [SerializeField] 
    private GameObject showcaseMenu;

    [SerializeField] 
    private GameObject showcase;
    
    public void RaceButton()
    {
        if (GameManager.CarSelected == -1)
        {
            GameManager.CarSelected = 0;
        }
        SceneManager.LoadScene(1);
    }
    
    public void SelectTrackButton()
    {
        mainMenu.SetActive(false);
        trackSelectMenu.SetActive(true);
    }

    public void SelectCarButton()
    {
        mainMenu.SetActive(false);
        showcaseMenu.SetActive(true);
        showcase.SetActive(true);
    }
    
    public void ShowcaseMenuBackButton()
    {
        mainMenu.SetActive(true);
        showcaseMenu.SetActive(false);
        showcase.SetActive(false);
    }

    public void TrackSelectBackButton()
    {
        mainMenu.SetActive(true);
        trackSelectMenu.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    
    public void Level1()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(3);
    }
}
