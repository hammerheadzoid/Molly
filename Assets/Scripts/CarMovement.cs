using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * https://www.youtube.com/watch?v=ViM_3sVb9-E    Unity3D Scripting: Translate and Rotate
 */

public class CarMovement : MonoBehaviour {

    public float hor;
    public float vert;
    public float rot;
    //float lockPos = 0;
    private Rigidbody rb;
    public Quaternion rotation = Quaternion.identity;
    bool fwdPermission, bckPermission;//, lftPermission, rthPermission;
    private int MollyInCarYN;                       // This variable keeps an eye on wheather Molly is in the car or not... if she is in the car it is set to "1", if she is not in the car "0"

    // Use this for initialization
    void Start () {
        hor = 30.0f;
        vert = 30.0f;
        rot = 100.0f;
        rb = GetComponent<Rigidbody>();
        fwdPermission = true;
        bckPermission = true;
        //stopMoving = GetComponent<RigidbodyConstraints>();
        //stopMoving = RigidbodyConstraints.FreezeRotationY;
    }
	
	// Update is called once per frame
	void Update () {


        //transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * vert);

        MollyInCarYN = PlayerPrefs.GetInt("MollyInCar");

        // 0 = Molly NOT in car
        // 1 = Molly IN car
        if (MollyInCarYN == 1)
        {

            // While a letter is pressed move
            if (Input.GetKeyDown(KeyCode.Space))
                Debug.Log("Space key was pressed.");

            // Move Up
            if (Input.GetKey("w") && fwdPermission == true)
            {
                transform.Translate(0f, 0f, -1.0f * Time.deltaTime * vert);
                print("w key was pressed");
            }

            if (Input.GetKey("s") && bckPermission == true)
            {
                transform.Translate(0f, 0f, 1.0f * Time.deltaTime * vert);
                print("s key was pressed");
            }


            /*if (Input.GetKey("a") && lftPermission == true)
            {
                transform.Translate(-1.0f * Time.deltaTime * hor, 0f, 0f);
                print("a key was pressed");
            }


            if (Input.GetKey("d") && rthPermission == true)
            {
                transform.Translate(1.0f * Time.deltaTime * hor, 0f, 0f);
                print("d key was pressed");
            }*/



            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.constraints = RigidbodyConstraints.None;
                //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Rotate(0f, -1.0f * Time.deltaTime * rot, 0f);
                    print("You rotated to the left");
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Rotate(0f, 1.0f * Time.deltaTime * rot, 0f);
                    print("You rotated to the right");
                }
            }
            else
            {
                //transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);
                // rotation.eulerAngles = new Vector3(0, 0, 0);

                //      rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

                //GetComponent<RigidbodyConstraints>().me RigidbodyConstraints.FreezeRotationY;
                print("You should not be spinning");
            }
        }      // End "MollyInCarYN"


    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Hotel")
        {
            print("This is the Hotel");
        }

        if (col.gameObject.name == "Cafe")
        {
            print("This is the Cafe");
        }

        if (col.gameObject.name == "Bank")
        {
            print("This is the Bank");
        }

        if (col.gameObject.name == "Shop")
        {
            print("This is the Shop");
        }

        if (col.gameObject.name == "Coin")
        {
            print("You found a coin!");
            Destroy(col.gameObject);
        }

    }

   /* void FixedUpdate()
    {
        int distance = 1;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 bck = transform.TransformDirection(Vector3.back);
        Vector3 lft = transform.TransformDirection(Vector3.left);
        Vector3 rth = transform.TransformDirection(Vector3.right);

        if (Physics.Raycast(transform.position, fwd, distance))
        {
            print("There is something in front of you Molly!");
            if (gameObject.name == "BankDoor")
            {
                print("This is the Bank");
            }
            fwdPermission = false;
        }
        else
        {
            fwdPermission = true;
        }
        
        if (Physics.Raycast(transform.position, bck, distance))
        {
            print("There is something in behind you Molly!");
            if (gameObject.name == "BankDoor")
            {
                print("This is the Bank");
            }
            bckPermission = false;
        }
        else
        {
            bckPermission = true;
        }

        if (Physics.Raycast(transform.position, lft, distance))
        {
            print("There is something to the left of you Molly!");
            if (gameObject.name == "BankDoor")
            {
                print("This is the Bank");
            }
            lftPermission = false;
        }
        else
        {
            lftPermission = true;
        }

        if (Physics.Raycast(transform.position, rth, distance))
        {
            print("There is something to the right of you Molly!");
            if (gameObject.name == "BankDoor")
            {
                print("This is the Bank");
            }
            rthPermission = false;
        }
        else
        {
            rthPermission = true;
        }
    }*/
}
