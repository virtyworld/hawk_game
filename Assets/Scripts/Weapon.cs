using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    [SerializeField] private Bullet[] bulletPrefabs;
    [SerializeField] private StreamBullet[] streamPrefabs;
  
    public Bullet Bullet => bulletPrefabs[Random.Range(0,bulletPrefabs.Length)];
    public StreamBullet StreamBullet => streamPrefabs[Random.Range(0,streamPrefabs.Length)];
   

}