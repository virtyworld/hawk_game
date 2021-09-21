using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector2 offset;
    private Transform target;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        Vector3 desirePosition = new Vector3(target.position.x + offset.x,
            target.position.y + offset.y, transform.position.z);
        transform.position = desirePosition;
    }
}