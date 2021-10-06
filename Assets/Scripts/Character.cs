using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
    [Header("Character setup")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fireRate;

    private enum Tags{Character,Player}
    private float currentTime;
    private bool isShoot;
    private bool isHoldMouse0;
    private Bullet[] bullet;

    public void Setup(Bullet[] bullet)
    {
        this.bullet = bullet;
    }

    private void FixedUpdate()
    {
        Shoot();
        Move();
    }
  
    //TODO: what is the best solutions: hit.transform.CompareTag(Tags.Character.ToString()) ||  Enum.TryParse || hit.transform.tag == Tags.Character.ToString()
    private void Move()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.tag == Tags.Character.ToString())
                {
                    isHoldMouse0 = true;
                    Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                    transform.position = Vector3.Lerp (transform.position, target ,  Time.deltaTime * moveSpeed);
                }  
            } 
            else if (isHoldMouse0)
            {
                Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                transform.position = Vector3.Lerp (transform.position, target ,  Time.deltaTime * moveSpeed);
            }
        }
        else
        {
            isHoldMouse0 = false;            
        }
    }

    private void Shoot()
    {
        if (currentTime == 0)
        {
            isShoot = true;
            Shooting();
        }

        if (isShoot && currentTime < fireRate)
        {
            currentTime += 1 * Time.deltaTime;
        }

        if (currentTime >= fireRate)
        {
            currentTime = 0;
            isShoot = false;
        }
    }

    private void Shooting()
    {
        Vector3 position = gameObject.transform.position;
        Instantiate(bullet[Random.Range(0, bullet.Length)].transform, new Vector3(position.x, position.y + 1), Quaternion.identity);
    }
}