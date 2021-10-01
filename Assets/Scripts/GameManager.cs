using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int CarSelected;

    public static GameObject[] Vehicles;

    [SerializeField]
    private GameObject[] vehicles;

    private static bool yes;
    
    private void Awake()
    {
        if (!yes)
        {
            CarSelected = -1;
            Vehicles = vehicles;
            yes = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(CarSelected);
    }
}
