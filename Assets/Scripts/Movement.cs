using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * https://www.youtube.com/watch?v=ViM_3sVb9-E    Unity3D Scripting: Translate and Rotate
 */

public class Movement : MonoBehaviour {

    public float hor;
    public float vert;
    public float rot;
    public float runningSpeed;
    public float stamina = 100f;
    public float looseStamina;
    public float recoverStaminia;
    //float lockPos = 0;
    private Rigidbody rb;
    public GameObject CanvasObject;
    public Text text;
    public Quaternion rotation = Quaternion.identity;
    bool fwdPermission, bckPermission;
    private int MollyInCarYN;      // This variable keeps an eye on wheather Molly is in the car or not... if she is in the car it is set to "1", if she is not in the car "0"

    // Use this for initialization
    void Start () {
        hor = 2.5f;     // how fast on the horizontal
        vert = 2.5f;    // how fast on the vertical
        rot = 60.0f;    // How fast does molly turn
        runningSpeed = 1.5f;    // When Shift is pressed - how fast does she run
        looseStamina = 2.5f;    // Rate at which stamina decreases
        recoverStaminia = 1.0f;
        PlayerPrefs.SetInt("MollyInCar", 0);        // This variable keeps an eye on wheather Molly is in the car or not... if she is in the car it is set to "1", if she is not in the car "0"
        rb = GetComponent<Rigidbody>();
        text.text = "Stamina : " + stamina;
    }
	
	// Update is called once per frame
	void Update () {

        //transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * vert);

        MollyInCarYN = PlayerPrefs.GetInt("MollyInCar");
        //print("Movement : MollyInCarYN sets Molly NOT in car as MollyInCarYN is " + MollyInCarYN + " and 0 is Molly is not in car.");

        // 0 = Molly is not in car
        if (MollyInCarYN == 0)
        {
            

            // Walk Forward
            if (Input.GetKey("w") && fwdPermission == true)
            {
                //transform.Translate(0f, 0f, 5.0f * Time.deltaTime * vert);

                transform.Translate(5.0f * Time.deltaTime * vert, 0f, 0f);
                //print("w key was pressed");
            }

            // Run Forward
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w") && fwdPermission == true && stamina > 0)
            {
                transform.Translate(5.0f * Time.deltaTime * (vert * runningSpeed), 0f, 0f);
                stamina = stamina - (looseStamina * Time.deltaTime);
                text.text = "Stamina : " + Mathf.Round(stamina);
                //print("SHIFT key was pressed");
            }
            
            // If Molly is not moving recover her stamina... she can still turn, go backward or strafe
            if (!Input.GetKey("w") && stamina < 100)
            {
                stamina = stamina + (recoverStaminia * Time.deltaTime);
                text.text = "Stamina : " + Mathf.Round(stamina);
            }

            // Walk Backward
            if (Input.GetKey("s") && bckPermission == true)
            {
                transform.Translate(-5.0f * Time.deltaTime * vert, 0f, 0f);
                //print("s key was pressed");
            }

            /* Step Left
            if (Input.GetKey("a") && lftPermission == true)
            {
                transform.Translate(-1.0f * Time.deltaTime * hor, 0f, 0f);
                //print("a key was pressed");
            }

            // Step Right
            if (Input.GetKey("d") && rthPermission == true)
            {
                transform.Translate(1.0f * Time.deltaTime * hor, 0f, 0f);
                //print("d key was pressed");
            }
            */

            // This section deals with Molly turn and stopping her spinning
            if (Input.GetKey("a") || Input.GetKey("d"))
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

                if (Input.GetKey("a"))
                {
                    transform.Rotate(0f, -1.0f * Time.deltaTime * rot, 0f);
                    //print("You rotated to the left");
                }

                if (Input.GetKey("d"))
                {
                    transform.Rotate(0f, 1.0f * Time.deltaTime * rot, 0f);
                    //print("You rotated to the right");
                }
            }
            else
            {
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                //print("You should not be spinning");
            }
            /*
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Rotate(0f, -1.0f * Time.deltaTime * rot, 0f);
                    //print("You rotated to the left");
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Rotate(0f, 1.0f * Time.deltaTime * rot, 0f);
                    //print("You rotated to the right");
                }
            }
            else
            {
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                //print("You should not be spinning");
            }
            */
        }       // End "MollyInCarYN"
    }       // End "Update"


    /*void OnCollisionEnter(Collision col)
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

        if (col.gameObject.name == "English Terraced House")
        {
            print("Ewww! A dirty old English terraced house.");
            
        }

    }*/

    
}
