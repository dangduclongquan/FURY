using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
{
    static GameObject prefab = (GameObject)Resources.Load("Bullet");

    GameObject gameObject;
    public Bullet(Vector3 position, Vector3 eulerAngles, float speed, float damage)
    {
        gameObject = GameObject.Instantiate(prefab, position, Quaternion.Euler(eulerAngles));
        BulletController bc = gameObject.GetComponent<BulletController>();
        bc.speed = speed;
        bc.damage = damage;
    }
}
