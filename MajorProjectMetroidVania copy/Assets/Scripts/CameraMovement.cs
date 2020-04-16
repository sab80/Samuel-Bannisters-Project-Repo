﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    if (player != null)
        {
            this.transform.position = new Vector3(player.position.x, player.position.y, -3f);
        }
    }
}
