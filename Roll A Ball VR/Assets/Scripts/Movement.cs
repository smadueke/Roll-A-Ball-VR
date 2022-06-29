using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public int score;
    public TextMeshProUGUI Text;
    public static Movement move;
    PlayerMovement moveInput;
    public Vector2 moveVector;


    private void Awake()
    {
        moveInput = new PlayerMovement();
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        move = this;
        score = Manager.manager.count;
        Text.text = "Pickups Left: " + score;
    }

    private void FixedUpdate()
    {

        if (Manager.manager.VRMode)
        {
            Vector3 movement = new Vector3(moveVector.x, 0, moveVector.y);
            rb.AddForce(movement * speed);
        }
        else
        {
            Vector2 move = moveInput.MovementControls.Movement.ReadValue<Vector2>();
            Vector3 movement = new Vector3(move.x, 0, move.y);
            rb.AddForce(movement * speed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            score -= 1;
            Text.text = "Pickups Left: " + score;
            Manager.manager.audios[2].Play();
            other.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        moveInput.MovementControls.Enable();
    }

    private void OnDisable()
    {
        moveInput.MovementControls.Disable();
    }
}
