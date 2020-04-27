using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Collisions : MonoBehaviour
{
    public Ball_Movement movement;

    public Game_Manager gameManager;

    public float launchTimer = 0f;

    float afterCollisionTimeLimit = 10f;

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

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "StopWall")
        {
            movement.enabled = false;
        }
        if (collisionInfo.collider.tag == "Pin") 
        {
            ballHasCollided = true;
        }
    }
}
