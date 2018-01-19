using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MollyLeavesCar : MonoBehaviour {

    // Get Molly and Car Game Objects
    public GameObject Molly;
    public Vector3 currentCarLocation;

    // Use this for initialization
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp("f"))
        {
            currentCarLocation = transform.position;
            print("Current location is " + currentCarLocation);
            print("Molly has left the car.");
            Molly.SetActive(true);
            PlayerPrefs.SetInt("MollyInCar", 0);
            Molly.transform.position = new Vector3(currentCarLocation.x, currentCarLocation.y, currentCarLocation.z + 5.0f);
        }
    }
}
