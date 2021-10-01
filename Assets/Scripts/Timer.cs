using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float totalSeconds;
    public float[] lapTime = new float[4];
    public static string[] lapTimeString = new string[4];
    public int lap;
    public float minutes;
    public float seconds;
    // Start is called before the first frame update
    void Start()
    {
        totalSeconds = 0;
        totalSeconds = 0;
        lap = -1;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        for (int i = 0; i < 3; i++)
        {
            if (lapTime[i] > 60)
            {
                lapTime[i] -= 60;
                minutes++;

                if (minutes > 59)
                {
                    hours += 1;
                    minutes -= 60;
                            
                }
                lapTimeString[i]= hours + ":" + minutes + ":" + lapTime[i];
            }
        }
        */
        if (Checkpoints.islapped)
        {
            lap++;
            switch (lap)
            {
                case 1:
                    lapTime[0] = totalSeconds;
                    break;
                
                case 2:
                    lapTime[1] = totalSeconds - lapTime[0];
                    break;
                
                case 3:
                    lapTime[2] = totalSeconds - (lapTime[1] + lapTime[0]);
                    break;
                
                case 4:
                    lapTime[3] = totalSeconds - (lapTime[2] + lapTime[1] + lapTime[0]);
                    break;
            }
            Checkpoints.islapped = false;
        }
        
        if (Checkpoints.isStarted)
        {
            totalSeconds += Time.deltaTime;
            /*
            if (seconds > 60)
            {
                seconds -= 60;
                minutes++;

                if (minutes > 59)
                {
                    hours += 1;
                    minutes -= 60;
                }
            }
            */
        }
        else
        {
            for (int i = 0; i < Checkpoints.TotalLaps; i++)
            {
                //print(lapTime[i]);
                seconds = lapTime[i];
                while (seconds >= 60)
                {
                    seconds -= 60;
                    minutes++;
                }
                lapTimeString[i] = minutes.ToString("#00") + ":" + seconds.ToString("#00.000s");
                minutes = 0;
            }
        }
    }
}
