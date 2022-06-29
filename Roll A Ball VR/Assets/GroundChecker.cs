using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    float distToGround;
    public bool grounded;

    public static GroundChecker groundCheckerScript;

    // Start is called before the first frame update
    void Start()
    {
        groundCheckerScript = this;
        distToGround = gameObject.GetComponent<SphereCollider>().radius;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, distToGround-0.05f, Vector3.down, out hit, 10))
        {
            grounded = true;
            Debug.Log("On the ground");
        }
        else
        {
            grounded = false;
            Debug.Log("Not on the ground");
        }
    }
}
