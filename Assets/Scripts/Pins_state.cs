using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins_state : MonoBehaviour
{
    public bool pinIsUp = true;
    public bool substractedFromTotalPins = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.eulerAngles.x < -45 | transform.rotation.eulerAngles.x > 45 |
            transform.rotation.eulerAngles.z < -45 | transform.rotation.eulerAngles.z > 45)
        {
            pinIsUp = false;
        }
    }
}
