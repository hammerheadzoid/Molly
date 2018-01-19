/*
 * Show the time of day on the canvas
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeOfDay : MonoBehaviour {

    public GameObject sunRotationTime;      // This is the object of the sun that is in the Hierarchy
    public float timeX;
    public float timeY;
    private bool nightTimeFlag;
    public GameObject theRotationTime;
    public GameObject onofflights1, onofflights2, onofflights3, onofflights4, onofflights5, onofflights6, onofflights7;
    public Vector3 myeulerAngles;           // Used to get where the rotation of the sun around map so i can get the time
    public Text text, textTimOfDay;
    public Text textIronAmount;
    public Text textRockAmount;
    public GameObject TheSunsLight;
    public GameObject TheMoonsLight;
    private int dayNum = 0; // To set the time of the day in a playerpref named "dayCounter"
    public GameObject prefab;
    public GameObject streetLightPreb;
    public GameObject healthDropPrefab;
    public GameObject ammoDropPrefab;
    public GameObject ironBarDropPrefab;
    private int spawnSiteNum;
    private Light lt;
    private Light ltMoon;


    // Use this for initialization
    void Start () {
        /* Thanks to http://answers.unity3d.com/questions/42843/referencing-non-static-variables-from-another-scri.html */
        
        // Use Find to find the sun and store it as a variable in the gameObject variable "theRotationTime"
            theRotationTime = GameObject.Find("Sun");
        // Now that we have the object "theRotationTime" get the component "sun" from it, store is as a new custom variable we 
        // just made up named "sunRotationSpeed". Use GetComponent to get the script "sun" that is attached to the object "Sun"
        //sun sunRotationSpeed = theRotationTime.GetComponent<sun>();  
        // Finally, create a float day and attribute the sunSpeed varible to it that is found in the custom variable "sunRotationSpeed"
        //day = sunRotationSpeed.sunSpeed;


        // myRotation = Quaternion.identity;        // Ahhhh this sets the quaternion to 0,0,0!

        //Vector3 sunRot = Quaternion.Euler(x,y,z);
        //sunVec = sunRot.rotation;
        //transform.rotation = Quaternion.Euler(x, 0, 0);
        //print(transform.eulerAngles);
        PlayerPrefs.SetInt("dayCounter", 0);
        PlayerPrefs.SetInt("spawnZombieBool", 0);
        dayNum = PlayerPrefs.GetInt("dayCounter");
        nightTimeFlag = false; // start at false, because it is morning when game begins.. right?
        textTimOfDay.text = "Day # : 0";
        textIronAmount.text = "Iron : 0";
        textRockAmount.text = "Rock : 0";
        lt = TheSunsLight.GetComponent<Light>();
        ltMoon = TheMoonsLight.GetComponent<Light>();

    }

    // https://docs.unity3d.com/ScriptReference/Random.Range.html
    void turnSunIntensityDown()
    {
        for (int i = 1; i < 100; i++)
        {
            if (lt.intensity > 0 )
            {
                lt.intensity = lt.intensity - 0.01f;
            }
            else
            {
                lt.intensity = 0;
            }
        }
    }

    void turnSunIntensityUp()
    {
        for (int i = 1; i < 100; i++)
        {
            if (lt.intensity <= 1)
            {
                lt.intensity = lt.intensity + 0.01f;
            }
            else
            {
                lt.intensity = 1;
            }
        }
    }

    void turnMoonIntensityDown()
    {
        for (int i = 1; i < 100; i++)
        {
            if (ltMoon.intensity > .5)
            {
                ltMoon.intensity = ltMoon.intensity - 0.01f;
            }
            else
            {
                ltMoon.intensity = 0;
            }
        }
    }

    void turnMoonIntensityUp()
    {
        for (int i = 1; i < 100; i++)
        {
            if (ltMoon.intensity <= .5)
            {
                ltMoon.intensity = ltMoon.intensity + 0.01f;
            }
            else
            {
                ltMoon.intensity = 1;
            }
        }
    }
    void randomInstance()
    {
        Vector3 position = new Vector3(Random.Range(-250.0f, 100.0f), 100, Random.Range(-250.0f, 100.0f));
        Instantiate(prefab, position, Quaternion.identity);
    }

    void setInstanceWarehouse()
    {
        Vector3 position = new Vector3(-250, 13, -234);
        Instantiate(prefab, position, Quaternion.identity);
    }

    void setInstanceTheHillA()
    {
        Vector3 position = new Vector3(-98, 42, -253);
        Instantiate(prefab, position, Quaternion.identity);
    }

    void setInstanceTheHillB()
    {
        Vector3 position = new Vector3(133, 42, -167);
        Instantiate(prefab, position, Quaternion.identity);
    }

    void setInstanceRussianBuilding()
    {
        Vector3 position = new Vector3(93.8f, 18, 98.17f);
        Instantiate(prefab, position, Quaternion.identity);
    }

    void setInstanceMountain()
    {
        Vector3 position = new Vector3(-182, 13, 96);
        Instantiate(prefab, position, Quaternion.identity);
    }

    void setInstanceShops()
    {
        Vector3 position = new Vector3(81, 13, -49);
        Instantiate(prefab, position, Quaternion.identity);
    }

    void setInstanceCouncilHouses()
    {
        Vector3 position = new Vector3(-135, 13, -34);
        Instantiate(prefab, position, Quaternion.identity);
    }

    void setInstanceCenterMap()
    {
        Vector3 position = new Vector3(-35, 13, -34);
        Instantiate(prefab, position, Quaternion.identity);
    }

    void setInstanceFoodDrop()
    {

        for (int i = 1; i <= 20; i++)
        {
            //Debug.Log("This is round number " + i + " of setInstance");
            Vector3 position = new Vector3(Random.Range(-250.0f, 100.0f), 100, Random.Range(-250.0f, 100.0f));
            Instantiate(healthDropPrefab, position, Quaternion.identity);
        }
        
    }

    void setInstanceAmmoDrop()
    {

        for (int i = 1; i <= 20; i++)
        {
            //Debug.Log("This is round number " + i + " of setInstance");
            Vector3 position = new Vector3(Random.Range(-250.0f, 100.0f), 100, Random.Range(-250.0f, 100.0f));
            Instantiate(ammoDropPrefab, position, Quaternion.identity);
        }

    }

    void setInstanceIronBarDrop()
    {

        for (int i = 1; i <= 20; i++)
        {
            //Debug.Log("This is round number " + i + " of setInstance");
            Vector3 position = new Vector3(Random.Range(-250.0f, 100.0f), 100, Random.Range(-250.0f, 100.0f));
            Instantiate(ironBarDropPrefab, position, Quaternion.identity);
        }

    }


    // Turn on all the street lights
    void streetLightsOn() {
        onofflights1.SetActive(true);
        onofflights2.SetActive(true);
        onofflights3.SetActive(true);
        onofflights4.SetActive(true);
        onofflights5.SetActive(true);
        onofflights6.SetActive(true);
        onofflights7.SetActive(true);
        streetLightPreb.SetActive(true);
    }

    void streetLightsOff() {
        //onofflights = GameObject.FindGameObjectWithTag("streetlight");
        onofflights1.SetActive(false);
        onofflights2.SetActive(false);
        onofflights3.SetActive(false);
        onofflights4.SetActive(false);
        onofflights5.SetActive(false);
        onofflights6.SetActive(false);
        onofflights7.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        myeulerAngles = theRotationTime.transform.eulerAngles;             // vector3 works here not quaternion

        timeX = myeulerAngles.x;
        timeY = myeulerAngles.y;

        //print("The day is number " + dayNum);
        
        
        /*
         * now show the time of day...
         */

        // This is 180 - going from brightness to dark
        if (timeY > 178 && timeY <= 180)
        {
            if (timeX > 270 && timeX < 285)
            {
                text.text = "Midnight - Mind the dead!";
                if (nightTimeFlag == false)
                {
                    nightTimeFlag = true;
                    dayNum++;       // add 1 to the day counter and save it in dayCounter pref
                    PlayerPrefs.SetInt("dayCounter", dayNum);
                    setInstanceFoodDrop();      // Drop random food amounts from the air
                    setInstanceAmmoDrop();      // Drop random ammo amounts from the air
                    setInstanceIronBarDrop();   // Drop Iron Bars from the sky!
                    for (int i = 1; i <= dayNum; i++)
                    {
                        //Debug.Log("This is round number " + i + " of day (or night rather) " + dayNum + " in spawn site number " + spawnSiteNum);

                        // Select site for zombies to spawn from
                        spawnSiteNum = Random.Range(1, 8);


                        if (spawnSiteNum == 1)
                        {
                            setInstanceWarehouse();
                        }
                        if (spawnSiteNum == 2)
                        {
                            setInstanceTheHillA();
                        }
                        if (spawnSiteNum == 3)
                        {
                            setInstanceTheHillB();
                        }
                        if (spawnSiteNum == 4)
                        {
                            setInstanceRussianBuilding();
                        }
                        if (spawnSiteNum == 5)
                        {
                            setInstanceMountain();
                        }
                        if (spawnSiteNum == 6)
                        {
                            setInstanceShops();
                        }
                        if (spawnSiteNum == 7)
                        {
                            setInstanceCouncilHouses();
                        }
                        if (spawnSiteNum == 8)
                        {
                            setInstanceCenterMap();
                        }
                    }
                    
                    PlayerPrefs.SetInt("spawnZombieBool", 1);
                    //dayNum = PlayerPrefs.GetInt("dayCounter");
                    textTimOfDay.text = "Day # : " + dayNum;
                    
                }
            }

            if (timeX > 285 && timeX < 300)
            {
                text.text = "11 pm";
                nightTimeFlag = false; // Set this to false so that the day counter will be increased 
            }

            if (timeX > 300 && timeX < 315)
            {
                text.text = "10pm";
            }

            if (timeX > 315 && timeX < 330)
            {
                text.text = "9 pm";
                // Turn off the light
                //turnSunIntensityDown();
                //turnMoonIntensityUp();
            }

            if (timeX > 330 && timeX < 345)
            {
                text.text = "8 pm";
            }

            if (timeX > 345 && timeX < 360)
            {
                text.text = "7 pm";
                streetLightsOn();
            }

            if (timeX > 0 && timeX < 15)
            {
                text.text = "6 pm";
            }

            if (timeX > 15 && timeX < 30)
            {
                text.text = "5 pm";
            }

            if (timeX > 30 && timeX < 45)
            {
                text.text = "4 pm";
            }

            if (timeX > 45 && timeX < 60)
            {
                text.text = "3 pm";
            }

            if (timeX > 60 && timeX < 75)
            {
                text.text = "2 pm";
            }
            if (timeX > 75 && timeX < 90)
            {
                text.text = "1 pm";
                //randomInstance(); // unblock this function to see like a hundred of something of chosen prefab falling at the same time... for testing where random range on terrain is
                //setInstanceWarehouse();
            }

        }

        // This is 0 - going from darkness to bright
        if (timeY > 0 && timeY < 15)
        {
            if (timeX > 270 && timeX <= 285)
            {
                text.text = "1am";
            }

            if (timeX >= 286 && timeX <= 300)
            {
                text.text = "2am";
            }

            if (timeX >= 301 && timeX <= 315)
            {
                text.text = "3am";
            }

            if (timeX >= 316 && timeX <= 330)
            {
                text.text = "4am";
            }

            if (timeX >= 330 && timeX <= 345)
            {
                text.text = "5am";
            }

            if (timeX >= 345 && timeX <= 360)
            {
                text.text = "6am";
                streetLightsOff();
                //turnSunIntensityUp();
                //turnMoonIntensityDown();
            }

            if (timeX >= 0 && timeX <= 15)
            {
                text.text = "7am";
            }

            if (timeX >= 16 && timeX <= 30)
            {
                text.text = "8am";
            }

            if (timeX >= 31 && timeX <= 45)
            {
                text.text = "9am";
            }

            if (timeX >= 46 && timeX <= 60)
            {
                text.text = "10am";
            }

            if (timeX >= 61 && timeX <= 75)
            {
                text.text = "11 am";
            }
            if (timeX >= 76 && timeX <=90 || timeX > 75 && timeX <= 89)
            {
                text.text = "12 Midday";
            }
        }

        //text.text = myeulerAngles.y.ToString();

        //Debug.Log("X is " + myeulerAngles.x);
        //Debug.Log("Y is " + myeulerAngles.y);

    }

}
