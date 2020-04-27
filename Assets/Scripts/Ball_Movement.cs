using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball_Movement : MonoBehaviour
{

    public Rigidbody ballBody;
    public Slider PowerSlider;

    bool goLeft = false;
    bool goRight = false;
    bool launch = false;

    float sidesForce = 500f;

    int force = 0;
    int forceAdded = 50;

    private void Start()
    {
        PowerSlider = FindObjectOfType<Slider>();
    }

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
            if (Input.GetKeyDown("w") && !launch && force < 500)
            {
                force += forceAdded;
            }
            if (Input.GetKeyDown("s") && !launch && force < 500)
            {
                force -= forceAdded;
            }
            if (Input.GetKey("space") && force >= forceAdded)
            {
                launch = true;
            }
        }
        PowerSlider.value = force;
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
