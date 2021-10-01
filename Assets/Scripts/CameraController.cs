using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 _playerPos;
    public bool enableHeightFollow;
    public float cameraXDistance;
    public float cameraYDistance = 4.5f;
    public float cameraZDistance;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerPos = player.transform.position;
        if (enableHeightFollow)
        {
            transform.position = new Vector3(_playerPos.x + cameraXDistance, _playerPos.y + cameraYDistance, _playerPos.z + cameraZDistance);
        }
        else
        {
            transform.position = new Vector3(_playerPos.x + cameraXDistance, cameraYDistance, _playerPos.z + cameraZDistance);
        }
    }
}
