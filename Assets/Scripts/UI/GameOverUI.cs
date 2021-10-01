using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] 
    private GameObject InGameUI;
    [SerializeField] 
    private GameObject GameOverMenu;

    [SerializeField] 
    private TextMeshProUGUI lapTimes;
    [SerializeField] 
    private TextMeshProUGUI totalTime;

    public bool yes;

    private string a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameOverEnabled();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void GameOverEnabled()
    {
        if (Checkpoints.gameOver)
        {
            //Checkpoints.gameOver = false;
            InGameUI.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameOverMenu.SetActive(true);

            
            StartCoroutine(time());

            /*
            lap1Time.text = "Lap 1- " + Timer.lapTimeString[0];
            lap2Time.text = "Lap 2- " + Timer.lapTimeString[1];
            lap3Time.text = "Lap 3- " + Timer.lapTimeString[2];
            lap4Time.text = "Lap 4- " + Timer.lapTimeString[3];
            */
        }
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(0.1f);
        
        if (!yes)
        {
            /*
            for (int i = 0; i < Checkpoints.TotalLaps; i++)
            {
                print(i);
                t.Append("Lap " + i++ + "- " + Timer.lapTimeString[i-1] + "\n");
                lap1Time.text = t.ToString();
                yes = true;
            }
            */

            for (int i = 0; i < Checkpoints.TotalLaps; i++)
            {
                //print(i);
                //print(Timer.lapTimeString[i]);
                a += "LAP " + (i + 1) + "- " + Timer.lapTimeString[i] + "\n \n";
            }

            float seconds = Timer.totalSeconds;
            float minutes = 0;
            while (seconds >= 60)
            {
                seconds -= 60;
                minutes++;
            }

            totalTime.text = "TOTAL TIME- " + minutes.ToString("00") + ":" + seconds.ToString("00.000s");
            lapTimes.text = a;
            yes = true;
        }
    }
}
