using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MollyStartPosition : MonoBehaviour
{

    public GameObject molly;

    // Use this for initialization
    void Start()
    {
        // Select site for zombies to spawn from
        int spawnSiteNum = Random.Range(1, 8);

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

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void setInstanceWarehouse()
    {
        molly.transform.position = new Vector3(-250, 13, -234);
    }

    void setInstanceTheHillA()
    {
        molly.transform.position = new Vector3(-98, 42, -253);
    }

    void setInstanceTheHillB()
    {
        molly.transform.position = new Vector3(133, 42, -167);
    }

    void setInstanceRussianBuilding()
    {
        molly.transform.position = new Vector3(93.8f, 20, 98.17f);
    }

    void setInstanceMountain()
    {
        molly.transform.position = new Vector3(-182, 20, 96);
    }

    void setInstanceShops()
    {
        molly.transform.position = new Vector3(81, 23, -49);
    }

    void setInstanceCouncilHouses()
    {
        molly.transform.position = new Vector3(-135, 23, -34);
    }

    void setInstanceCenterMap()
    {
        molly.transform.position = new Vector3(-35, 20, -34);
    }
}
