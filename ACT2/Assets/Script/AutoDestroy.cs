﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

	public float exitTime = 1;
    // Use this for initialization
	void Start () {
		Destroy(this.gameObject,exitTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
