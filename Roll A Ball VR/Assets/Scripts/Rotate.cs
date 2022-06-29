using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    private Vector3 rotate;
    void Awake()
    {
        rotate = new Vector3(Random.Range(0, 20), Random.Range(0, 20), Random.Range(0, 20));
    }
    private void FixedUpdate()
    {
        transform.Rotate(rotate * speed * Time.deltaTime);
    }
}
