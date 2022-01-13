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
        MovePlayerJoystick();
        RotateTurretJoystick();
    }

    private void MovePlayerJoystick()
    {
        if (GetInput("Horizontal", "Vertical") && (moveJoystick.xAxis.value != 0 || moveJoystick.yAxis.value != 0))
        {
            MovePlayer();
        }
        else
        {
            StopMovePlayer();
        }
    }

    private void MovePlayerKeyboard()
    {
        if (Input.GetKey(KeyCode.A))
        {
            cubeRb.velocity = Vector3.Normalize(new Vector3(-input.x * speed, 0, 0));
        }
    }

    private void MovePlayer()
    {
        cubeRb.velocity = Vector3.Normalize(new Vector3(input.x, 0, input.y)) * speed;
    }

    private void StopMovePlayer()
    {
        cubeRb.velocity = Vector3.zero;
    }

    private void RotateTurretJoystick()
    {
        if (GetInput("MouseX", "MouseY"))
        {
            RotateTurret();
        }
    }

    private void RotateTurret()
    {
        rotator.eulerAngles = new Vector3(0, Mathf.Atan2(input.x, input.y) * 180 / Mathf.PI, 0);
    }

    bool GetInput(string horizontal, string vertical)
    {
        input.x = SimpleInput.GetAxisRaw(horizontal) * speed;
        input.y = SimpleInput.GetAxisRaw(vertical) * speed;

        return (Mathf.Abs(input.x) > 0.01f) || (Mathf.Abs(input.y) > 0.01f);
    }

}
