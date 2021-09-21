using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteStreamBullet : StreamBullet
{
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        firePoint = GameObject.FindWithTag("firePoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        ShootStream(); 
    }
}
