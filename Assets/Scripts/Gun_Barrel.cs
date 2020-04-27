using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class Gun_Barrel : MonoBehaviour
{
    public float rayDistance = 1000;

    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, rayDistance))
        {
            Debug.DrawRay(transform.position, transform.up * hit.distance, Color.yellow);
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up * rayDistance, Color.white);
        }
    }
}
