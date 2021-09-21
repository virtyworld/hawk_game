using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D myRigibody;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        myRigibody.velocity = direction.normalized * speed;
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }
}