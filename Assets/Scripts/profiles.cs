using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class profiles : MonoBehaviour {

    //private int numberless = 7;
    //public int lathedAmmo = 8;
    public TMP_Text profile_1_Day;
    public TMP_Text profile_1_Ammo;
    public TMP_Text profile_1_Lathed;
    public TMP_Text profile_1_Iron;
    public TMP_Text profile_1_Rock;
    public TMP_Text profile_1_LathedXP;
    public TMP_Text profile_2_Day;
    public TMP_Text profile_2_Ammo;
    public TMP_Text profile_2_Lathed;
    public TMP_Text profile_2_Iron;
    public TMP_Text profile_2_Rock;
    public TMP_Text profile_2_LathedXP;
    public TMP_Text profile_3_Day;
    public TMP_Text profile_3_Ammo;
    public TMP_Text profile_3_Lathed;
    public TMP_Text profile_3_Iron;
    public TMP_Text profile_3_Rock;
    public TMP_Text profile_3_LathedXP;
    public TMP_Text profile_4_Day;
    public TMP_Text profile_4_Ammo;
    public TMP_Text profile_4_Lathed;
    public TMP_Text profile_4_Iron;
    public TMP_Text profile_4_Rock;
    public TMP_Text profile_4_LathedXP;

    // Use this for initialization
    void Start () {
        
        int dayCounter = PlayerPrefs.GetInt("profile1_dayCounter");
        profile_1_Day.text = dayCounter.ToString();

        int ShotGunAmmo = PlayerPrefs.GetInt("profile1_ShotGunAmmo");
        profile_1_Ammo.text = ShotGunAmmo.ToString();

        int lathedAmmo = PlayerPrefs.GetInt("profile1_lathedAmmo");
        profile_1_Lathed.text = lathedAmmo.ToString();

        int IronTot = PlayerPrefs.GetInt("profile1_IronTot");
        profile_1_Iron.text = IronTot.ToString();

        int RockTot = PlayerPrefs.GetInt("profile1_RockTot");
        profile_1_Rock.text = RockTot.ToString();

        int latheExperience = PlayerPrefs.GetInt("profile1_latheExperience");
        profile_1_LathedXP.text = latheExperience.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        int dayCounter = PlayerPrefs.GetInt("profile1_dayCounter");
        profile_1_Day.text = dayCounter.ToString();

        int ShotGunAmmo = PlayerPrefs.GetInt("profile1_ShotGunAmmo");
        profile_1_Ammo.text = ShotGunAmmo.ToString();

        int lathedAmmo = PlayerPrefs.GetInt("profile1_lathedAmmo");
        profile_1_Lathed.text = lathedAmmo.ToString();

        int IronTot = PlayerPrefs.GetInt("profile1_IronTot");
        profile_1_Iron.text = IronTot.ToString();

        int RockTot = PlayerPrefs.GetInt("profile1_RockTot");
        profile_1_Rock.text = RockTot.ToString();

        int latheExperience = PlayerPrefs.GetInt("profile1_latheExperience");
        profile_1_LathedXP.text = latheExperience.ToString();

    }
}
