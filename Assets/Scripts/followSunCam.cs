using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followSunCam : MonoBehaviour {

    public Transform targetPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        transform.LookAt(targetPos.position);
    }
}
