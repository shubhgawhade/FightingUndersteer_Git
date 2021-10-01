using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowcaseControl : MonoBehaviour
{
    [SerializeField]
    private GameObject[] showcasedCars;
    
    [Space]
    [Space]
    [SerializeField]
    private GameObject prev;
    
    [SerializeField]
    private GameObject next;

    public float rotationSpeed;
    public int currentCar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateAround();
        ButtonActivate();
        ChangingCars();
    }

    private void RotateAround()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        print("R");
        transform.Rotate(transform.up, rotationSpeed * Time.fixedDeltaTime);

        /*
        float pivRot = rotationSpeed * verticalInput * Time.deltaTime;
        transform.rotation = Quaternion.Euler(Mathf.Clamp(pivRot, -30, 30), 0, 0);

        float rot = verticalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.right, Mathf.Clamp(rot, -30, 30));
        */
    }

    private void ButtonActivate()
    {
        if (GameManager.CarSelected == 0)
        {
            prev.SetActive(false);
            next.SetActive(true);
        }
        else if (GameManager.CarSelected == GameManager.Vehicles.Length - 1)
        {
            next.SetActive(false);
            prev.SetActive(true);
        }
        else if (GameManager.CarSelected == -1)
        {
            GameManager.CarSelected = 0;
            currentCar = GameManager.CarSelected;
        }
        else
        {
            prev.SetActive(true);
            next.SetActive(true);
        }
    }

    private void ChangingCars()
    {
        print(currentCar);
        if (currentCar != GameManager.CarSelected)
        {
            showcasedCars[currentCar].SetActive(false);
            showcasedCars[GameManager.CarSelected].SetActive(true);
            currentCar = GameManager.CarSelected;
        }
        else
        {
            showcasedCars[GameManager.CarSelected].SetActive(true);
        }
        
        

        /*
        foreach (GameObject a in showcasedCars)
        {
            if (currentCar != GameManager.CarSelected)
            {
                a.SetActive(false);
            }
            else
            {
                a.SetActive(true);
            }
        }
        */
    }

    public void nextButton()
    {
        GameManager.CarSelected++;
    }

    public void prevButton()
    {
        GameManager.CarSelected--;
    }
}
