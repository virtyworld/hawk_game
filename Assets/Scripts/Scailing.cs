using System;
using UnityEngine;

public class Scailing : MonoBehaviour
{
    public static Scailing Instance;
    
    private float scale;
    public float GetScale => scale;

    private void Awake()
    {
        if (Instance == null) { 
            Instance = this; 
        } else if(Instance == this){ 
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        scale = (float)UnityEngine.Screen.width / UnityEngine.Screen.height;
    }
}
