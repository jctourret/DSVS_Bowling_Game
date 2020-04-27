using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Pos : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;

    public Quaternion rotationToLine;

    int followLimit = -10;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position + offset;
        transform.rotation = rotationToLine;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > followLimit)
        {
            transform.position = player.position + offset;
            transform.rotation = rotationToLine;
        }
    }
}
