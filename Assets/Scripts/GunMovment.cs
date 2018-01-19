using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GunMovment : MonoBehaviour {

    public Rigidbody rocketPrefab;
    public Transform barrelEnd;
    public float damage = 10f;
    public float range = 100f;
    public Text ammoLeft;
    public Text txtLathedAmmo;
    public Text txtLathedExperience;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    private int shotGunAmmo = 20;
    private int lathedAmmo = 0;
    private int lathedExperience = 0;
    //private float verticalMouseAxis = 0.0f;

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("ShotGunAmmo", shotGunAmmo);
        PlayerPrefs.SetInt("lathedAmmo", 0);
        shotGunAmmo = PlayerPrefs.GetInt("ShotGunAmmo");
        lathedAmmo = PlayerPrefs.GetInt("lathedAmmo");
        lathedAmmo = PlayerPrefs.GetInt("lathedAmmo");
        ammoLeft.text = shotGunAmmo.ToString();
        txtLathedAmmo.text = lathedAmmo.ToString();
        txtLathedExperience.text = lathedExperience.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        } 
    }
    
    void Shoot()
    {
        

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
        }

        shotGunAmmo = PlayerPrefs.GetInt("ShotGunAmmo");

        if (shotGunAmmo == 0)
        {
            print("No more bullets");
        }
        else
        {
            // Play sound
            AudioSource shoot = GetComponent<AudioSource>();
            shoot.Play();

            // Everything else
            muzzleFlash.Play();
            Rigidbody rocketInstance;
            rocketInstance = Instantiate(rocketPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            rocketInstance.AddForce(barrelEnd.forward * 20000);
            shotGunAmmo = shotGunAmmo - 1;
            PlayerPrefs.SetInt("ShotGunAmmo", shotGunAmmo);
            ammoLeft.text = shotGunAmmo.ToString();
            // print("You have " + shotGunAmmo + " shotgun shells left!");
        }
    }
}
