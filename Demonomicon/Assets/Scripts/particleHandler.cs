﻿using UnityEngine;
using System.Collections;

public class particleHandler : MonoBehaviour {

	public Transform particle;
	public Transform ember;

	// Use this for initialization
	void Start () {
		int particleLimit = 35;
		for (int i = 0; i < particleLimit; i++) {
            Instantiate(particle,new Vector3(0, 0, 0), Quaternion.identity);
        }

        int emberLimit = 14;
        for (int i = 0; i < emberLimit; i++) {
            Instantiate(ember,new Vector3(0, 0, 0), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
