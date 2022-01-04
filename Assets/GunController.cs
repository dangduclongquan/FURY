using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    //[SerializeField] GameObject bullet;
    [SerializeField] Transform barrel;
    public float bulletSpeed;
    public float bulletDamage;
    public float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float cooldown;
    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if(Input.GetMouseButton(0) && cooldown<=0)
        {
            new Bullet(barrel.position, barrel.eulerAngles, bulletSpeed, bulletDamage);
            //GameObject newBullet = Instantiate(bullet, barrel.position, barrel.rotation);
            cooldown = 1 / fireRate;
        }
    }
}
