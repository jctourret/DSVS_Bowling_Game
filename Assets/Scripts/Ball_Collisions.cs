using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Collisions : MonoBehaviour
{
    public Ball_Movement movement;

    float launchTimer = 0f;

    float afterCollisionTimeLimit = 10f;

    public bool ballHasCollided = false;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "StopWall")
        {
            movement.enabled = false;
        }
        if (collisionInfo.collider.tag == "pin") 
        {
            ballHasCollided = true;
            if (launchTimer <= afterCollisionTimeLimit && ballHasCollided)
            {
                launchTimer += Time.deltaTime;
            }
            if (launchTimer > afterCollisionTimeLimit)
            {
                ballHasCollided = false;
                FindObjectOfType<Game_Manager>().triesLeft--;
                FindObjectOfType<Game_Manager>().Restart();
            }
        }
    }
}
