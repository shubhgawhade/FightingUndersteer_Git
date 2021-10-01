using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    //public GameObject[] checkpoints = new GameObject[4];
    private Rigidbody rb;
    
    public int nextCheckpoint = 1;
    public static int lap = 0;

    public int totalLaps;
    public static int TotalLaps;

    public static bool gameOver;
    public static bool islapped;
    public static bool isStarted;
    // Start is called before the first frame update
    void Start()
    {
        TotalLaps = totalLaps;
        lap = 0;
        gameOver = false;
        islapped = false;
        isStarted = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TotalLaps == 0 || totalLaps == 0)
        {
            totalLaps = 4;
        }
        TotalLaps = totalLaps;
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (nextCheckpoint == 1 && lap == 0)
            {
                transform.position = CheckpointsManager.checkpoints[0].transform.position;
                transform.rotation = Quaternion.Euler(new Vector3(0, CheckpointsManager.checkpoints[0].transform.rotation.eulerAngles.y - 90, 0));
                rb.velocity = Vector3.zero;
            }
            else if (nextCheckpoint == 1 && lap > 0)
            {
                transform.position = CheckpointsManager.checkpoints[CheckpointsManager.checkpoints.Length - 2].transform.position;
                transform.rotation = Quaternion.Euler(new Vector3(0, CheckpointsManager.checkpoints[CheckpointsManager.checkpoints.Length - 2].transform.rotation.eulerAngles.y - 90, 0));
                rb.velocity = Vector3.zero;
            }
            else
            {
                transform.position = CheckpointsManager.checkpoints[nextCheckpoint - 2].transform.position;
                transform.rotation = Quaternion.Euler(new Vector3(0, CheckpointsManager.checkpoints[nextCheckpoint - 2].transform.rotation.eulerAngles.y - 90, 0));
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            switch (nextCheckpoint)
            {
                case 1:
                    isStarted = true;
                    islapped = true;
                    lap++;
                    break;
            }
            
            foreach (GameObject a in CheckpointsManager.checkpoints)
            {
                if (nextCheckpoint == CheckpointsManager.checkpoints.Length - 1 && lap < totalLaps)
                {
                    nextCheckpoint = 0;
                }
                
                other.gameObject.SetActive(false);
                CheckpointsManager.checkpoints[nextCheckpoint].SetActive(true);
                nextCheckpoint++;
                break;
            }
        }
        else if (other.gameObject.CompareTag("Finish") && lap == totalLaps)
        {
            nextCheckpoint = 2;
            islapped = true;
            isStarted = false;
            gameOver = true;
        }
    }
}
