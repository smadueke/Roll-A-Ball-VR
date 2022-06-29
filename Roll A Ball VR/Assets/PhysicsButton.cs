using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float threshold = .1f;
    [SerializeField] private float deadZone = 0.025f;

    public bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public Vector2 vector2Value;
    public static PhysicsButton physicsButtonScript;

    public UnityEvent onPressed, onReleased;
    
    void Start()
    {
        physicsButtonScript = this;
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if (_isPressed && GetValue() - threshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if(Math.Abs(value) < deadZone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }

    void Pressed()
    {
        _isPressed = true;
        Movement.move.moveVector = vector2Value;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }

    void Released()
    {
        _isPressed = false;
        Movement.move.moveVector = new Vector2(0,0);
        onReleased.Invoke();
        Debug.Log("Released");
    }
}
