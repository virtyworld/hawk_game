using UnityEngine;

public class Enemy1 : Enemy
{

    private void FixedUpdate()
    {
        //Shoot();
    }
   
    // private void Shoot()
    // {
    //     if (currentTime == 0)
    //     {
    //         isShoot = true;
    //         Vector3 position = gameObject.transform.position;
    //         // Instantiate(bulletLauncherPrefab[Random.Range(0, bulletLauncherPrefab.Length)].transform, new Vector3(position.x, position.y - 1,position.z), Quaternion.identity);
    //        
    //     }
    //
    //     if (isShoot && currentTime < fireRate)
    //     {
    //         currentTime += 1 * Time.deltaTime;
    //     }
    //
    //     if (currentTime >= fireRate)
    //     {
    //         currentTime = 0;
    //         isShoot = false;
    //     }
    // }
    
}