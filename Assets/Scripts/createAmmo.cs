using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class createAmmo : MonoBehaviour {

    public GameObject CanvasObject;
    public Text textIronAmount;
    public Text textAmmoAmount;
    public Text textRockAmount;
    public Text txtLathedAmmo;
    public Text txtLathedExperience;

    private int iron;
    private int rock;
    private int latheXP = 2;
    private int ironBars;
    private int ironTotal;
    private int rockTotal;
    private int shotGunAmmo;
    private int lathedAmmo;
    private int sendLathedXP;
    private int lathedShells;
    private int currentAmountOfLathedShells;

    // Use this for initialization
    void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Once you are hit once by ghost zombie 
    private void OnTriggerEnter(Collider other)
    {
        //print("Printed from OnTriggerEnter");

        if (other.gameObject.tag == "Lathe")
        {
            ironBars = PlayerPrefs.GetInt("IronTot");

            if (Input.GetKey("e") && ironBars > 0)
            {
                print("you are at the lathe and pressed x");
                latheXP = PlayerPrefs.GetInt("latheExperience");
                print("You got " + latheXP + " amount of Lathe XP this time");
                // If "e" is pressed and lathedAmmo is greater than 0 there is a certain 
                // amount of chance that shells will be created
                lathedShells = Random.Range(1, latheXP);

                PlayerPrefs.SetInt("latheExperience", latheXP = latheXP + 1);

                lathedAmmo = PlayerPrefs.GetInt("lathedAmmo");
                PlayerPrefs.SetInt("lathedAmmo", lathedAmmo = lathedAmmo + lathedShells);
                PlayerPrefs.SetInt("IronTot", iron = iron - 1);

                ironTotal = PlayerPrefs.GetInt("IronTot");
                textIronAmount.text = "Iron : " + ironTotal;

                lathedAmmo = PlayerPrefs.GetInt("lathedAmmo");
                txtLathedAmmo.text = "" + lathedAmmo;

                sendLathedXP = PlayerPrefs.GetInt("latheExperience");
                txtLathedExperience.text = "" + sendLathedXP;
            }
            print("you are at the lathe");
        }

        if (other.gameObject.tag == "Mill")
        {
            lathedAmmo = PlayerPrefs.GetInt("lathedAmmo");
            print("you are holding " + lathedAmmo + " remaining.");

            if (Input.GetKey("e") && lathedAmmo > 0)
            {
                print("you are at the mill and pressed x");
                
                lathedAmmo = PlayerPrefs.GetInt("lathedAmmo");
                PlayerPrefs.SetInt("lathedAmmo", lathedAmmo = lathedAmmo -1);
                print("you have " + lathedAmmo + " remaining.");
                txtLathedAmmo.text = "" + lathedAmmo;

                shotGunAmmo = PlayerPrefs.GetInt("ShotGunAmmo");
                PlayerPrefs.SetInt("ShotGunAmmo", shotGunAmmo = shotGunAmmo + 1);
                textAmmoAmount.text = "" + shotGunAmmo;
            }

            lathedAmmo = PlayerPrefs.GetInt("lathedAmmo");
            print("you are at the Mill");
        }

        if (other.gameObject.tag == "IronRod")
        {
            PlayerPrefs.SetInt("IronTot", iron = iron + 1);
            ironTotal = PlayerPrefs.GetInt("IronTot");
            textIronAmount.text = "Iron : " + ironTotal; 
            print("You found an IronRod");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Rock")
        {
            PlayerPrefs.SetInt("RockTot", rock = rock + 1);
            ironTotal = PlayerPrefs.GetInt("RockTot");
            textRockAmount.text = "Rock : " + ironTotal;
            print("You found a Rock");
            Destroy(other.gameObject);
        }
    }
}
