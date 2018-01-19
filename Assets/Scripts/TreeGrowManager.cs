using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowManager : MonoBehaviour {
    public float maxSize;
    public float growRate;
    public float scale = 0.0f;
    //float colorVariations = Color[];

	// Use this for initialization
	void Start () {
        maxSize = Random.Range(0.1f, 0.5f);
        PlayerPrefs.SetFloat("maxGrowSize", maxSize);
        //print("Max grow size for " + gameObject.name + " is " + maxSize);
        growRate = Random.Range(0.02f, 0.06f);
        //this.transform.Find("Bush_04").GetComponent.< Renderer > ().material.color = colorVariations[Random.Range(0, (colorVariations.Length))];
    }
	
	// Update is called once per frame
	void Update () {
        if (scale < maxSize)
        {
            this.transform.localScale = Vector3.one * scale;
            scale += growRate * (Time.deltaTime/100);
        }

    }
}
