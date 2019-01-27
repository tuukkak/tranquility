using System;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    float MouseSensitivity = 10f;
    sbyte LastInputX;
    sbyte LastInputZ;
    Movement Movement = State.CurrentPlayer.Movement;

    void Update()
    {
        UpdateMovement();
    }

    void UpdateMovement()
    {
        Movement.InputX = (sbyte)Input.GetAxisRaw("Horizontal");
        Movement.InputZ = (sbyte)Input.GetAxisRaw("Vertical");

        if (Movement.InputX != LastInputX || Movement.InputZ != LastInputZ)
        {
            Network.UpdateMovement();
        }

        LastInputX = Movement.InputX;
        LastInputZ = Movement.InputZ;

        if (Input.GetMouseButton(1))
        {
            Movement.Rotation = CalculateRotation();
        }
    }

    float CalculateRotation()
    {
        float Rotation = Movement.Rotation + (Input.GetAxis("Mouse X") * MouseSensitivity);
        Rotation = (float)Math.Round(Rotation, 3);
        while (Rotation < 0) Rotation += 360f;
        while (Rotation > 360) Rotation -= 360f;
        return Rotation;
    }
}
