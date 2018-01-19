using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public float health = 100f;
    public float MollysHealth = 100f;
    public GameObject CanvasObject;
    public Text text;                   // for the setting of health on screen
    public Text ammoText;               // for the setting of ammo on screen
    private int randHealth;             // store result of random number gen for health during health drop
    private int healthLow = 1;          // bottom range of health during health drop
    private int healthHigh = 10;        // bottom range of health during health drop
    private int randAmmo;               // store result of random number gen for ammo during an ammo drop
    private int ammoLow = 1;            // bottom range of ammo during an ammo drop
    private int ammoHigh = 10;          // bottom range of ammo during an ammo drop

    // Use this for initialization
    void Start () {
        // Mollys Health Starts Off At 100
        PlayerPrefs.SetFloat("MollysHealth", health);
        PlayerPrefs.SetInt("latheExperience", 0);
        PlayerPrefs.SetInt("lathedAmmo", 0);
        //MollysHealth = PlayerPrefs.GetInt("MollysHealth");
    }
	
	// Update is called once per frame
	void Update () {
        MollysHealth = PlayerPrefs.GetFloat("MollysHealth");
        text.text = "Health : " + Mathf.Round(MollysHealth);

        if (MollysHealth <= 0)
        {
            //Application.Quit();
            loadMenu();
            print("Ahhh I have just diedddddddd......");
        }
	}

    public void loadMenu()
    {
        //int currentProfile = PlayerPrefs.GetInt("currentProfile");
        int currentProfile = 1;
        if (currentProfile == 1)
        {
            print("You are within the load menu section");

            int dayCounter = PlayerPrefs.GetInt("dayCounter");
            PlayerPrefs.SetInt("profile1_dayCounter", dayCounter);

            int ShotGunAmmo = PlayerPrefs.GetInt("ShotGunAmmo");
            PlayerPrefs.SetInt("profile1_ShotGunAmmo", ShotGunAmmo);

            int lathedAmmo = PlayerPrefs.GetInt("lathedAmmo");
            PlayerPrefs.SetInt("profile1_lathedAmmo", lathedAmmo);

            int IronTot = PlayerPrefs.GetInt("IronTot");
            PlayerPrefs.SetInt("profile1_IronTot", IronTot);

            int RockTot = PlayerPrefs.GetInt("RockTot");
            PlayerPrefs.SetInt("profile1_RockTot", RockTot);

            int latheExperience = PlayerPrefs.GetInt("latheExperience");
            PlayerPrefs.SetInt("profile1_latheExperience", latheExperience);
        }

        SceneManager.LoadScene(0); // 0 is the menu screen // set to 1 if you want to restart level away when you die
        print("This is from the loadMenu function......");
    }


    // Once you are hit once by ghost zombie 
    private void OnTriggerEnter(Collider other)
    {
        //print("Printed from OnTriggerEnter");
            
        if (other.gameObject.tag == "Zombie")
        {
            PlayerPrefs.SetFloat("MollysHealth", health = health - 5);
            //print("Molly Is Hurt By A Zombie - OnTriggerEnter." + health);
        }

        if (other.gameObject.tag == "TastyBush")
        {
            //randHealth = Random.Range(healthLow, healthHigh);
            PlayerPrefs.SetFloat("MollysHealth", health = health + 40);
            //other.gameObject.Destroy(gameObject, 19.0f);
            Destroy(other.gameObject);
            //print("Molly Is Hurt By A Zombie - OnTriggerEnter." + health);
        }

        if (other.gameObject.tag == "healthCube")
        {
            randHealth = Random.Range(healthLow, healthHigh);
            PlayerPrefs.SetFloat("MollysHealth", health = health + randHealth);
            //other.gameObject.Destroy(gameObject, 19.0f);
            Destroy(other.gameObject);
            //print("Molly Is Hurt By A Zombie - OnTriggerEnter." + health);
        }

        if (other.gameObject.tag == "ammoCube")
        {
            int currentAmmo = PlayerPrefs.GetInt("ShotGunAmmo");
            randAmmo = Random.Range(ammoLow, ammoHigh);
            PlayerPrefs.SetInt("ShotGunAmmo", currentAmmo = currentAmmo + randAmmo);
            currentAmmo = PlayerPrefs.GetInt("ShotGunAmmo");
            ammoText.text = currentAmmo.ToString();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //print("Printed from OnTriggerStay");

        if (other.gameObject.tag == "Zombie")
        {
            PlayerPrefs.SetFloat("MollysHealth", health = health - 0.1f);
            //print("Molly Is Hurt By A Zombie - OnTriggerStay." + health);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //print("Printed from OnTriggerExit");

        if (other.gameObject.tag == "Zombie")
        {
            PlayerPrefs.SetFloat("MollysHealth", health = health - 2);
            //print("Molly Is Hurt By A Zombie - OnTriggerExit." + health);
        }
    }
}
