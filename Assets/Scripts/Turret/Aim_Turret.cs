using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim_Turret : MonoBehaviour
{
    public Transform Base;
    public Transform Body;

    bool turnBase = false;
    bool turnGun = false;

    public float baseRotSpeed = 50;
    public float bodyRotSpeed = 25;

    Vector3 baseTemp;
    Vector3 bodyTemp;
    Quaternion baseLookRotation;
    Quaternion bodyLookRotation;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        Vector3 mousepos = Input.mousePosition;

        Ray ray = cam.ScreenPointToRay(mousepos);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);
        Debug.DrawRay(Base.transform.position, Base.forward *200, Color.white);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 200))
            {
                baseTemp = hit.point - Base.position;
                bodyTemp = hit.point - Body.position;
                baseTemp.y = 0f;
                baseLookRotation = Quaternion.LookRotation(baseTemp);
                bodyLookRotation = Quaternion.LookRotation(bodyTemp);
                Debug.Log(hit.transform.position);
                turnBase = true;
            }
        }
        if (turnBase)
        {
            Base.rotation = Quaternion.Slerp(Base.rotation, baseLookRotation, baseRotSpeed * Time.deltaTime);
            if (Base.rotation == baseLookRotation)
            {
                turnBase = false;
                turnGun = true;
            }
        }
        if (turnGun)
        {
            Body.rotation = Quaternion.Slerp(Body.rotation, bodyLookRotation, bodyRotSpeed * Time.deltaTime);
            if (Body.rotation == bodyLookRotation)
            {
                turnGun = false;
            }
        }
    }
}
