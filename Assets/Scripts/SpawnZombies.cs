using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour {

    //[SerializeField]
    public GameObject NewZombie;
    private int dayNum = 0;
    private int token = 0;          // The token is to count the days! 

	// Use this for initialization
	void Start () {
        //NewZombie = GameObject.FindWithTag("Zombie");
        token = 0;
        
        
    }
	
	// Update is called once per frame
	void Update () {

        token = PlayerPrefs.GetInt("spawnZombieBool");

        if (token == 1)
        {
            if (NewZombie == null)
            {
                Debug.Log("The zombie did not work! :( " + gameObject.name);
            }
            else
            {
                dayNum = PlayerPrefs.GetInt("dayCounter");

                for (int i = 1; i <= dayNum; i++)
                {
                    Instantiate(NewZombie);
                    print("A new zombie spawned from " + gameObject.name);
                }

                token = 0;
                PlayerPrefs.SetInt("spawnZombieBool", token);
            }
        }
        

    }
}
