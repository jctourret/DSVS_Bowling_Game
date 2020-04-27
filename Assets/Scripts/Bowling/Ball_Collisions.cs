using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Collisions : MonoBehaviour
{
    public Ball_Movement movement;

    public Game_Manager gameManager;

    public float launchTimer = 0f;

    float afterCollisionTimeLimit = 10f;

    bool fellToPit = false;

    int pitForce = 500;

    public bool ballHasCollided = false;

    public void Update()
    {
        if (ballHasCollided)
        {
            if (launchTimer <= afterCollisionTimeLimit && ballHasCollided)
            {
                launchTimer += Time.deltaTime;
            }
            if (launchTimer > afterCollisionTimeLimit)
            {
                ballHasCollided = false;
                gameManager.triesLeft--;
                gameManager.Restart();
            }
        }
    }

    private void FixedUpdate()
    {
        if (fellToPit)
        {

            movement.ballBody.AddForce(-pitForce * Time.deltaTime, 0, 0);

        }
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "StopWall")
        {
            movement.enabled = false;
            ballHasCollided = true;
        }
        if (collisionInfo.collider.tag == "Pit")
        {
            fellToPit = true;
        }
        if (collisionInfo.collider.tag == "Pin") 
        {
            ballHasCollided = true;
        }
    }
}
