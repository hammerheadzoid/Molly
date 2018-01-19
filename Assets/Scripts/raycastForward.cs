using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raycastForward : MonoBehaviour {

    /*
     * https://www.youtube.com/watch?v=6agwCUaMNWI
     */

    public GameObject CanvasObject;
    public Text text;

    // Use this for initialization
    void Start () {
        
        PlayerPrefs.SetString("BuildingName","John");
        text.text = "";
        //CanvasObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        float theDistance;

        // This is the debug raycast to make life easier
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position,forward,Color.green);

        if (Physics.Raycast(transform.position, (forward), out hit)) {
            theDistance = hit.distance;
            //print(theDistance + " " + hit.collider.gameObject.name);
            if (theDistance < 1.1)
            {
                CanvasObject.SetActive(true);
                //PlayerPrefs.SetString("BuildingName", gameObject.name);
                if (hit.collider.gameObject.name == "Hotel")
                {
                    text.text = "Do you want to enter the " + hit.collider.gameObject.name;
                    print("Do you want to enter the " + hit.collider.gameObject.name);
                }
                // Interact with object
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    print("You are now in the " + hit.collider.gameObject.name);
                }
            }
            else
            {
                CanvasObject.SetActive(false);
            }
        }
	}
}
