using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating_Ship_Controller : MonoBehaviour
{
    [SerializeField] float rotatingSpeed = 1f;
    [SerializeField] Fire fire;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-Vector3.forward, Time.deltaTime* rotatingSpeed);
     
    }
}
