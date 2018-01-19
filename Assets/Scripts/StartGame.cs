using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public GameObject MollysCarCam;     // This is the camera on Mollys car... turn it off at the beginning of the game, afterwards, MollyEnterCar and MollyLeavesCar deals with the camera coming on or off

    // Use this for initialization
	void Start () {
        // 0 = Molly NOT in car
        // 1 = Molly IN car
        PlayerPrefs.SetInt("MollyInCar", 0);
        //print("StartGame : Molly begins NOT in car.");

        // Turn of the camera on mollys car...
        MollysCarCam.SetActive(false);
        //print("StartGame : Mollys CarCam is off.");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey("escape"))
        {
            print("Quitting game");
            SceneManager.LoadScene(0); // 0 is the menu screen

            //Application.Quit();
        }
            
    }
}
