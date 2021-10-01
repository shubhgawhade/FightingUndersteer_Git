using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;
    private Rigidbody rb;
    
    [SerializeField]
    private TextMeshProUGUI warningText;

    [SerializeField] 
    private TextMeshProUGUI lapText;
    
    [SerializeField] 
    private TextMeshProUGUI timerText;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        player = Spawner.car;
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LapTextDisplay();
        TimerDisplay();
        WarningTextDisplay();
    }

    private void LapTextDisplay()
    {
        lapText.text = "LAP: " + Checkpoints.lap + "/" + Checkpoints.TotalLaps;
    }

    private void TimerDisplay()
    {
        timerText.text = Timer.totalSeconds.ToString(("#0.000s"));
    }

    private void WarningTextDisplay()
    {
        //print(rb.velocity.magnitude + " " + warningText.alpha);
        if (rb.velocity.magnitude < 0.5f)
        {
            if (warningText.alpha < 1)
            {
                warningText.alpha += Time.deltaTime * 0.8f;
            }
            //warningText.text = "Press 'R' to Reset to last checkpoint";
        }
        else
        {
            if (warningText.alpha > 0)
            {
                warningText.alpha -= Time.deltaTime * 2;
            }
        }
    }
}
