using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]protected  int damage;
    [SerializeField]protected  GameObject impactEffect ;

    public int Damage
    {
        get => damage;
        set => damage = value;
    }

    public GameObject ImpactEffect
    {
        get => impactEffect;
        set => impactEffect = value;
    }
}
