using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // Destroy the bullet after 1.5 seconds
        Destroy(gameObject, 1.5f);
	}

    private void OnTriggerEnter(Collider other)
    {
        //print("Printed from OnTriggerEnter");

        if (other.gameObject.tag == "Zombie")
        {
            ///PlayerPrefs.SetFloat("MollysHealth", health = health - 5);
            print("you shot a zombie");
            Destroy(other.gameObject);  // Destroy Zombie
            Destroy(gameObject);        // Destroy Bullet
        }

       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TerrainPlayArea")
        {
            print("you shot the ground");
            Destroy(gameObject);
        }
    }
}
