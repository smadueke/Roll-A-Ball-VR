using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private Vector3 offset;
    private bool offsetChecked;

    void Start()
    {
        offset = Player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {     
        transform.position = Player.transform.position - offset;
    }

}
