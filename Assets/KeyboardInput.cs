using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    //This script is executed before every other script in the project
    private Vector3 _moveDirection;
    public Vector3 MoveDirection { get { return _moveDirection; } private set { _moveDirection = value; } }

    private bool aPressed;
    private bool dPressed;
    public static event Action<Vector3> OnMove;
    public static event Action OnLeft;
    public static event Action OnRight;


    void Start()
    {
        MoveDirection = Vector3.forward;
        aPressed = false;
        dPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("a"))
        {
            float a = MoveDirection.x;
            float b = MoveDirection.y;
            float c = MoveDirection.z;
            MoveDirection = new Vector3(-c, b, a);
            aPressed = true;
        }



        if (Input.GetKeyDown("d"))
        {
            float a = MoveDirection.x;
            float b = MoveDirection.y;
            float c = MoveDirection.z;
            MoveDirection = new Vector3(c, b, -a);
            dPressed = true;
        }

        if (MoveDirection != Vector3.zero) OnMove(MoveDirection);
        if (aPressed)
        {
            OnLeft();
            aPressed = false;
        }

        if (dPressed)
        {
            OnRight();
            dPressed = false;
        }



    }
}
