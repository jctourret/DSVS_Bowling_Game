using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Movement : MonoBehaviour
{

    public Rigidbody ballBody;

    bool goLeft = false;
    bool goRight = false;
    bool launch = false;

    float sidesForce = 500f;

    int force = 0;
    int forceAdded = 10;
    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType <Game_Manager>().triesLeft > 0)
        {
            if (Input.GetKey("a") && !launch)
            {
                goLeft = true;
            }
            else
            {
                goLeft = false;
            }
            if (Input.GetKey("d") && !launch)
            {
                goRight = true;
            }
            else
            {
                goRight = false;
            }
            if (Input.GetKey("w") && !launch)
            {
                force += forceAdded;
            }
            if (Input.GetKey("s") && !launch)
            {
                force -= forceAdded;
            }
            if (Input.GetKey("space") && force >= forceAdded)
            {
                launch = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (goLeft)
        {
            ballBody.AddForce(0, 0, -sidesForce * Time.deltaTime);
        }
        if (goRight)
        {
            ballBody.AddForce(0, 0, sidesForce * Time.deltaTime);
        }
        if (launch)
        {
            ballBody.AddForce(-force * Time.deltaTime, 0, 0);
        }
    }
}
