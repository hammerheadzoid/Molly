/*
 * Brilliant quick solution to all of my sun intensity problem!
 * 
 * https://docs.unity3d.com/ScriptReference/Light-intensity.html
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour {

    private float sunSpeed = 5.01f;
    private float timeX;
    private float timeY;
    private Vector3 myeulerAngles;           // Used to get where the rotation of the sun around map so i can get the time
    private GameObject theRotationTime;
    
    public float duration = 24.0F;
    public Light lt;

    // Use this for initialization
    void Start () {
        theRotationTime = GameObject.Find("Sun");
        //lt = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("Printed from OnTriggerEnter");

        if (other.gameObject.tag == "HorizonIndicator")
        {
            Debug.Log("The sun went around...");
        }
    }
    
    // Update is called once per frame
    void Update () {

        /*float phi = Time.time / duration * 0.024F * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
        lt.intensity = amplitude;
        */

        transform.RotateAround(Vector3.zero, Vector3.right, sunSpeed * Time.deltaTime);
        transform.LookAt(Vector3.zero);

        myeulerAngles = theRotationTime.transform.eulerAngles;             // vector3 works here not quaternion

        timeX = myeulerAngles.x;
        timeY = myeulerAngles.y;

        /*
         * now show the time of day...
         */

        // This is 180 - going from brightness to dark
        if (timeY > 178 && timeY <= 180)
        {
            
            if (timeX > 270 && timeX < 285)
            {
                //text.text = "Midnight";
            }

            if (timeX > 285 && timeX < 300)
            {
               // text.text = "11 pm";
            }

            if (timeX > 300 && timeX < 315)
            {
                //text.text = "10pm";
            }

            if (timeX > 315 && timeX < 330)
            {
               // text.text = "9 pm";
            }

            if (timeX > 330 && timeX < 345)
            {
                //text.text = "8 pm";
            }

            if (timeX > 345 && timeX < 360)
            {
                //text.text = "7 pm";
            }

            if (timeX > 0 && timeX < 15)
            {
                //text.text = "6 pm";
            }

            if (timeX > 15 && timeX < 30)
            {
                //text.text = "5 pm";
            }

            if (timeX > 30 && timeX < 45)
            {
               // text.text = "4 pm";
            }

            if (timeX > 45 && timeX < 60)
            {
              //  text.text = "3 pm";

            }

            if (timeX > 60 && timeX < 75)
            {
                //text.text = "2 pm";
               // streetLightsOn();
            }
            if (timeX > 75 && timeX < 90)
            {
               // text.text = "1 pm";
            }

        }

        // This is 0 - going from darkness to bright
        if (timeY > 0 && timeY < 15)
        {
            

            if (timeX > 270 && timeX <= 285)
            {
               // text.text = "1am";
            }

            if (timeX >= 286 && timeX <= 300)
            {
              //  text.text = "2am";
            }

            if (timeX >= 301 && timeX <= 315)
            {
               // text.text = "3am";
            }

            if (timeX >= 316 && timeX <= 330)
            {
              //  text.text = "4am";
            }

            if (timeX >= 330 && timeX <= 345)
            {
               // text.text = "5am";
            }

            if (timeX >= 345 && timeX <= 360)
            {
              //  text.text = "6am";
             //   streetLightsOff();
            }

            if (timeX >= 0 && timeX <= 15)
            {
               // text.text = "7am";
            }

            if (timeX >= 16 && timeX <= 30)
            {
              //  text.text = "8am";
            }

            if (timeX >= 31 && timeX <= 45)
            {
              //  text.text = "9am";
            }

            if (timeX >= 46 && timeX <= 60)
            {
              //  text.text = "10am";
            }

            if (timeX >= 61 && timeX <= 75)
            {
              //  text.text = "11 am";
            }
            if (timeX >= 76 && timeX <= 90 || timeX > 75 && timeX <= 89)
            {
             //   text.text = "12 Midday";
            }
        }

        //text.text = myeulerAngles.y.ToString();

        //Debug.Log("X is " + myeulerAngles.x);
        //Debug.Log("Y is " + myeulerAngles.y);

    }

}
