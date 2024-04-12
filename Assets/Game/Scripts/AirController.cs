using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AirController : MonoBehaviour
{
    float moveInputX, moveInputY;
    [SerializeField] float movingSpeed = 1f;
    public Action MovingEvent;

    Joystick joystick;
    Camera cam;
    private void Start()
    {
        joystick = GameManager.GetJoyStick_Event?.Invoke();
        cam = GameManager.GetCameraEvent?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetButton("Horizontal");
        var vertical = Input.GetButton("Vertical");
        if (horizontal)
        {
            moveInputX = Input.GetAxis("Horizontal");
            Movement(transform.right, moveInputX);
        }

        if (vertical)
        {
            moveInputY = Input.GetAxis("Vertical");
            Movement(transform.up, moveInputY);

        }
        if ((!horizontal) && (!vertical))
            if (Input.GetMouseButton(0))
                FollowMouse();
    }
    void Movement(UnityEngine.Vector3 dir,float factor)
    {
       
        UnityEngine.Vector3 direction = dir * factor;
        transform.position = UnityEngine.Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
        if (factor != 0)
        {
            MovingEvent?.Invoke();
         
        }
    }
    void FollowMouse()
    {

        Vector3 pos = UnityEngine.Vector3.MoveTowards(transform.position, cam.ScreenToWorldPoint(Input.mousePosition), movingSpeed * 20f * Time.deltaTime);
        pos.z = 0;
        transform.position = pos;
        MovingEvent?.Invoke();
    }
}


