﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectMoving : MonoBehaviour {
    
    public float speed;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime); 
    }
}
