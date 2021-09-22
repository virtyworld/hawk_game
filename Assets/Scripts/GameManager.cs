using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject bulletRed;
    [SerializeField] private GameObject bulletBlue;

    private void Start()
    {
        character = Instantiate(character);
    }
}
