﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour {
    public GameObject camara;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(0, camara.transform.position.y - 3.46f, 0);
	}
}
