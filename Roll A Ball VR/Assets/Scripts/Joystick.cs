using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform topOjJoystick;

    [SerializeField]
    private float forwardBackwardTilt = 0;
    [SerializeField]
    private float sideToSideTilt = 0;

    Quaternion initialRotation;

    public static Joystick joystickScript;

    public Vector2 joystickVector2;

    private void Awake()
    {
        joystickScript = this;
        initialRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        forwardBackwardTilt = topOjJoystick.rotation.eulerAngles.x;
        sideToSideTilt = topOjJoystick.rotation.eulerAngles.z;

        if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
        {
            forwardBackwardTilt = Mathf.Abs(forwardBackwardTilt - 360);
            //Debug.Log("Backward" + forwardBackwardTilt);
            if (Mathf.Abs(forwardBackwardTilt) > 30)
            {
                joystickVector2 = new Vector2(0, -1);
                Debug.Log("Backward" + joystickVector2);
            }
        }
        else if (forwardBackwardTilt > 5 && forwardBackwardTilt < 74)
        {
            //Debug.Log("Forward" + forwardBackwardTilt);
            if (Mathf.Abs(forwardBackwardTilt) > 30)
            {
                joystickVector2 = new Vector2(0, 1);
                Debug.Log("Forward" + joystickVector2);
            }
        }

        else if (sideToSideTilt < 355 && sideToSideTilt > 290)
        {
            sideToSideTilt = Mathf.Abs(sideToSideTilt - 360);
            //Debug.Log("Right" + sideToSideTilt);
            if (Mathf.Abs(forwardBackwardTilt) > 30)
            {
                joystickVector2 = new Vector2(1, 0);
                Debug.Log("Right" + joystickVector2);
            }
        }
        else if (sideToSideTilt > 5 && sideToSideTilt < 74)
        {
            //Debug.Log("Left" + sideToSideTilt);
            if (Mathf.Abs(forwardBackwardTilt) > 30)
            {
                joystickVector2 = new Vector2(-1, 0);
                Debug.Log("Left" + joystickVector2);
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("PlayerHand"))
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        transform.rotation = initialRotation;
        joystickVector2 = new Vector2(0,0);
    }

}
