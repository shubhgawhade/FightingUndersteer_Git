using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] 
    //private GameObject[] vehicles;

    public static GameObject car;

    //public int vehicleChosen;
    public Transform pos;
    
    private void Awake()
    {
        print(GameManager.CarSelected);
        switch (GameManager.CarSelected)
        {
            default:
                car = Instantiate(GameManager.Vehicles[GameManager.CarSelected], pos.transform.position, Quaternion.Euler(0, 90, 0));
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
