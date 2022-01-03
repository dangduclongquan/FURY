using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    public float speed;
    public float damage;
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = rigidBody.transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.collider.gameObject.GetComponent<Health>();
        if (health!=null)
        {
            health.DealDamage(damage);
        }
        Destroy(gameObject);
    }
}
