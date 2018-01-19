using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIronBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Object.Destroy(gameObject, 30.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
