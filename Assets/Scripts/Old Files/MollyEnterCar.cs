using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MollyEnterCar : MonoBehaviour {

    // Get Molly and Car Game Objects
    public GameObject Molly;
    public GameObject MollysCarCam;
    public Vector3 currentCarLocation;

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {

        // Molly goes into the car
        if (Input.GetKeyUp("f"))   
        {
            PlayerPrefs.SetInt("MollyInCar", 1);        // If Molly is in the car, then set this otherwise have it set to "0"
            print("Molly has entered the car...");
            Molly.SetActive(false);
            print("Molly is set to inactive.");
            MollysCarCam.SetActive(true);
            print("MollysCarCam is turned on.");
        }

        // Molly get out of the car
        if (Input.GetKeyUp("e"))
        {
            currentCarLocation = transform.position;
            print("Current location is " + currentCarLocation);
            print("Molly has left the car.");
            Molly.SetActive(true);
            MollysCarCam.SetActive(false);
            PlayerPrefs.SetInt("MollyInCar", 0);
            Molly.transform.position = new Vector3(currentCarLocation.x, currentCarLocation.y, currentCarLocation.z + 5.0f);
        }
    }
}
