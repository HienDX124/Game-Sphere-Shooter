using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleInputNamespace;

public class playerMovement : MonoBehaviour
{
    public Transform rotator;
    private Rigidbody cubeRb;

    public float speed = 5.0f;

    private Vector2 input;

    public Joystick moveJoystick;

    void Start()
    {
        cubeRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        if (GetInput("Horizontal", "Vertical") && (moveJoystick.xAxis.value != 0 || moveJoystick.yAxis.value != 0))
        {
            MovePlayer();
        }
        else
        {
            StopMovePlayer();
        }

        if (GetInput("MouseX", "MouseY"))
        {
            RotateTurret();
        }
    }

    bool GetInput(string horizontal, string vertical)
    {
        input.x = SimpleInput.GetAxisRaw(horizontal) * speed;
        input.y = SimpleInput.GetAxisRaw(vertical) * speed;

        return (Mathf.Abs(input.x) > 0.01f) || (Mathf.Abs(input.y) > 0.01f);
    }

    void StopMovePlayer()
    {
        cubeRb.velocity = Vector3.zero;
    }

    void MovePlayer()
    {
        cubeRb.velocity = Vector3.Normalize(new Vector3(input.x, 0, input.y)) * speed;
    }

    void RotateTurret()
    {
        rotator.eulerAngles = new Vector3(0, Mathf.Atan2(input.x, input.y) * 180 / Mathf.PI, 0);
    }
}
