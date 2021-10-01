using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public static bool isPaused;

    [SerializeField]
    private GameObject pauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    
    // Update is called once per frame
    void Update()
    {
        PauseButton();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void BackButton()
    {
        isPaused = false;
    }

    private void PauseButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Checkpoints.gameOver)
        {
            if (isPaused && !Checkpoints.gameOver)
            {
                isPaused = false;
            }
            else
            {
                isPaused = true;
            }   
        }

        if (isPaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else if(!Checkpoints.gameOver)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }
}
